using Kakomi.InGame.Data.DataStore;
using Kakomi.InGame.Data.Entity;
using Kakomi.InGame.Domain.Repository.Interface;
using UnityEngine;

namespace Kakomi.InGame.Domain.Repository
{
    public sealed class StageDataRepository : IStageDataRepository
    {
        private readonly StageDataEntity _stageDataEntity;
        
        public StageDataRepository(int level, StageDataTable stageDataTable)
        {
            var stageData = stageDataTable.stageDataList[level];
            _stageDataEntity = JsonUtility.FromJson<StageDataEntity>(stageData.ToString());
        }

        public StageDataEntity stageDataEntity => _stageDataEntity;
    }
}