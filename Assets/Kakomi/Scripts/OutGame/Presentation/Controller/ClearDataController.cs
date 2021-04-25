using Kakomi.OutGame.Domain.UseCase.Interface;
using Kakomi.OutGame.Presentation.View;
using UnityEngine;
using Zenject;

namespace Kakomi.OutGame.Presentation.Controller
{
    public sealed class ClearDataController : MonoBehaviour
    {
        [SerializeField] private LevelButtonView[] levelButtonViews = default;

        [Inject]
        private void Construct(IClearDataUseCase clearDataUseCase)
        {
            var clearData = clearDataUseCase.LoadClearData();
            for (int i = 0; i < clearData.Length; i++)
            {
                levelButtonViews[i].ActivateClearLabel(clearData[i]);
            }
        }
    }
}