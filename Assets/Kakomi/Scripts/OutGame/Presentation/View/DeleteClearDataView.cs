using Kakomi.Common.Application;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Kakomi.OutGame.Presentation.View
{
    public sealed class DeleteClearDataView : MonoBehaviour
    {
        [SerializeField] private Button deleteButton = default;
        [SerializeField] private LevelButtonView[] levelButtonViews = default;

        private void Start()
        {
            deleteButton
                .OnClickAsObservable()
                .Subscribe(_ =>
                {
                    for (int i = 0; i < levelButtonViews.Length; i++)
                    {
                        ES3.Save(SaveKey.STAGE + (i + 1), false);
                        levelButtonViews[i].LoadClearData();
                    }
                })
                .AddTo(this);
        }
    }
}