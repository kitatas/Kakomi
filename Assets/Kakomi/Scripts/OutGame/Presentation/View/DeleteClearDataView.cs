using Kakomi.OutGame.Domain.UseCase.Interface;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Kakomi.OutGame.Presentation.View
{
    public sealed class DeleteClearDataView : MonoBehaviour
    {
        [SerializeField] private Button deleteButton = default;
        [SerializeField] private LevelButtonView[] levelButtonViews = default;

        private IClearDataUseCase _clearDataUseCase;

        [Inject]
        private void Construct(IClearDataUseCase clearDataUseCase)
        {
            _clearDataUseCase = clearDataUseCase;
        }

        private void Start()
        {
            deleteButton
                .OnClickAsObservable()
                .Subscribe(_ =>
                {
                    _clearDataUseCase.DeleteAllClearData();
                    ResetClearLabel();
                })
                .AddTo(this);
        }

        private void ResetClearLabel()
        {
            foreach (var stageButton in levelButtonViews)
            {
                stageButton.ActivateClearLabel(false);
            }
        }
    }
}