using Kakomi.Common.Application;
using UnityEngine;

namespace Kakomi.Common.Data.DataStore
{
    [CreateAssetMenu(fileName = "BgmTable", menuName = "DataTable/BgmTable", order = 0)]
    public sealed class BgmTable : ScriptableObject
    {
        [SerializeField] private AudioClip title = default;
        [SerializeField] private AudioClip menu = default;
        [SerializeField] private AudioClip game = default;

        public AudioClip[] GetBgmList()
        {
            var bgmCount = System.Enum.GetValues(typeof(BgmType)).Length;
            var bgmList = new AudioClip[bgmCount];
            bgmList[(int) BgmType.Title] = title;
            bgmList[(int) BgmType.Menu]  = menu;
            bgmList[(int) BgmType.Game]  = game;

            return bgmList;
        }
    }
}