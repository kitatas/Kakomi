using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Kakomi.InGame.Application;
using Kakomi.InGame.Factory;
using Kakomi.InGame.Presentation.Controller;
using Kakomi.InGame.Presentation.View.Interface;
using Kakomi.Utility;
using UnityEngine;
using Zenject;

namespace Kakomi.InGame.Presentation.View
{
    public abstract class BaseEnclosureObject : MonoBehaviour, IEnclosureObject
    {
        [SerializeField] private EnclosureObjectView enclosureObjectView = default;

        public abstract int EffectValue { get; }
        public abstract EnclosureObjectType EnclosureObjectType { get; }

        private readonly float _moveSpeed = 0.25f;
        private bool _isEnclose;
        private int _direction;

        [SerializeField] private Color coreColor = default;

        private CancellationToken _token;
        private GameController _gameController;
        private EncloseEffectFactory _encloseEffectFactory;

        [Inject]
        private void Construct(GameController gameController, EncloseEffectFactory encloseEffectFactory)
        {
            _token = this.GetCancellationTokenOnDestroy();
            _gameController = gameController;
            _encloseEffectFactory = encloseEffectFactory;

            enclosureObjectView.Initialize(coreColor);
        }

        public void Init(Vector2 initializePosition, int direction, Action action)
        {
            _isEnclose = false;
            _direction = direction;
            transform.position = initializePosition;
            var moveVector = new Vector3(0, _direction);

            enclosureObjectView.SpawnAsync(_token).Forget();

            UniTask.Void(async _ =>
            {
                await UniTask.WhenAny(
                    UniTask.WaitUntil(() => _isEnclose, cancellationToken: _token),
                    Move(moveVector));

                // poolに返却
                action?.Invoke();
            }, this);
        }

        private UniTask Move(Vector3 moveVector)
        {
            return UniTask.WaitWhile(() =>
            {
                if (_isEnclose)
                {
                    return false;
                }

                if (_gameController.IsMoveObject)
                {
                    transform.position += moveVector * Time.fixedDeltaTime * _moveSpeed;
                }

                var y = transform.position.y;
                return
                    y > FieldParameter.yPoints[0] - FieldParameter.INTERVAL &&
                    y < FieldParameter.yPoints.GetLastParam() + FieldParameter.INTERVAL;
            }, PlayerLoopTiming.FixedUpdate, _token);
        }

        public virtual void Enclose(Action<int> action)
        {
            _isEnclose = true;
            _encloseEffectFactory.Activate(transform.position, coreColor);

            // 再生成
            action?.Invoke(_direction);
        }
    }
}