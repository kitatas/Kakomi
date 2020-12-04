using Kakomi.Common.Application;
using Kakomi.OutGame.Domain.Repository.Interface;

namespace Kakomi.OutGame.Domain.Repository
{
    public sealed class ClearDataRepository : IClearDataRepository
    {
        public bool LoadClearData(int level)
        {
            return ES3.Load(SaveKey.STAGE + level, false);
        }

        public void DeleteClearData(int level)
        {
            ES3.Save(SaveKey.STAGE + level, false);
        }
    }
}