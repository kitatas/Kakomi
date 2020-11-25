using Kakomi.Common.Application;
using UnityEngine;

namespace Kakomi.Common.Data.DataStore
{
    [CreateAssetMenu(fileName = "SeTable", menuName = "DataTable/SeTable", order = 0)]
    public sealed class SeTable : ScriptableObject
    {
        [SerializeField] private AudioClip decision = default;
        [SerializeField] private AudioClip cancel = default;
        [SerializeField] private AudioClip enclose = default;
        [SerializeField] private AudioClip attack = default;
        [SerializeField] private AudioClip damage = default;
        [SerializeField] private AudioClip recover = default;
        [SerializeField] private AudioClip clear = default;
        [SerializeField] private AudioClip failed = default;

        public AudioClip[] GetSeList()
        {
            var seCount = System.Enum.GetValues(typeof(SeType)).Length;
            var seList = new AudioClip[seCount];
            seList[(int) SeType.Decision] = decision;
            seList[(int) SeType.Cancel]   = cancel;
            seList[(int) SeType.Enclose]  = enclose;
            seList[(int) SeType.Attack]   = attack;
            seList[(int) SeType.Damage]   = damage;
            seList[(int) SeType.Recover]  = recover;
            seList[(int) SeType.Clear]    = clear;
            seList[(int) SeType.Failed]   = failed;

            return seList;
        }
    }
}