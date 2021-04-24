using Kakomi.Common.Presentation.View;
using TMPro;
using UnityEngine;

namespace Kakomi.InGame.Presentation.View
{
    public sealed class GameFinishView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI finishText = default;
        [SerializeField] private SceneLoadView sceneLoadView = default;

        public void Init()
        {
            SetFinishText("");
            ActivateSceneLoad(false);
        }

        public void SetFinishText(string message)
        {
            finishText.text = $"{message}";
        }

        public void ActivateSceneLoad(bool value)
        {
            sceneLoadView.enabled = value;
        }
    }
}