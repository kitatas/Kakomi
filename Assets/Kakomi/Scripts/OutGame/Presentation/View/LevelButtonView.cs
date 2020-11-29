using Kakomi.Common.Application;
using Kakomi.Common.Presentation.Controller;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Kakomi.OutGame.Presentation.View
{
    [RequireComponent(typeof(Button))]
    public sealed class LevelButtonView : MonoBehaviour
    {
        [SerializeField] private int level = default;
        [SerializeField] private TextMeshProUGUI levelText = default;
        [SerializeField] private TextMeshProUGUI clearText = default;

        private SceneLoader _sceneLoader;

        [Inject]
        private void Construct(SceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;

            levelText.text = $"Level.{level}";

            LoadClearData();
        }

        private void Start()
        {
            GetComponent<Button>()
                .OnClickAsObservable()
                .Subscribe(_ => _sceneLoader.LoadScene(SceneName.Main, level))
                .AddTo(this);
        }

        public void LoadClearData()
        {
            var isClear = ES3.Load(SaveKey.STAGE + level, false);
            clearText.gameObject.SetActive(isClear);
        }
    }
}