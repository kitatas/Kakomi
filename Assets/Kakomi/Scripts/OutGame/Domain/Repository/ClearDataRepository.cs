using Kakomi.Common.Application;
using Kakomi.Common.Data.DataStore;
using Kakomi.OutGame.Domain.Repository.Interface;

namespace Kakomi.OutGame.Domain.Repository
{
    public sealed class ClearDataRepository : IClearDataRepository
    {
        public bool[] LoadClearData()
        {
            return ES3.Load(SaveKey.STAGE, ClearDataStore.GetDefaultData());
        }

        public void DeleteClearData()
        {
            ES3.Save(SaveKey.STAGE, ClearDataStore.GetDefaultData());
        }
    }
}