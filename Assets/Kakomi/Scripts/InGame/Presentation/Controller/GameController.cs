using UnityEngine;

namespace Kakomi.InGame.Presentation.Controller
{
    public sealed class GameController : MonoBehaviour
    {
        [SerializeField] private bool isMoveObject = default;
        public bool IsMoveObject => isMoveObject;
    }
}