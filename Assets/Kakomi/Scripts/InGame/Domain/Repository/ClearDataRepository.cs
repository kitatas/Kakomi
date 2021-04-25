using Kakomi.Common.Application;
using Kakomi.Common.Data.DataStore;
using Kakomi.InGame.Domain.Repository.Interface;

namespace Kakomi.InGame.Domain.Repository
{
    public sealed class ClearDataRepository : IClearDataRepository
    {
        private readonly int _level;
        private readonly bool[] _clearData;

        public ClearDataRepository(int level)
        {
            _level = level;
            _clearData = LoadClearData();
        }

        private static bool[] LoadClearData()
        {
            return ES3.Load(SaveKey.STAGE, ClearDataStore.GetDefaultData());
        }

        public void SaveClearData()
        {
            // clear済みの場合
            if (_clearData[_level])
            {
                return;
            }

            _clearData[_level] = true;
            ES3.Save(SaveKey.STAGE, _clearData);
        }
    }
}