using Kakomi.InGame.Data.Entity;
using Kakomi.InGame.Data.Entity.Interface;
using Kakomi.InGame.Domain.Model;
using Kakomi.InGame.Domain.Model.Interface;
using Kakomi.InGame.Domain.Repository.Interface;
using Kakomi.InGame.Domain.UseCase.Interface;
using UniRx;

namespace Kakomi.InGame.Domain.UseCase
{
    public sealed class StageDataUseCase : IPlayerDataUseCase, IEnemyDataUseCase, IStageDataUseCase
    {
        private readonly ICharacterEntity _playerEntity;
        private readonly ICharacterEntity _enemyEntity;
        private readonly IHpModel _playerHpModel;
        private readonly IHpModel _enemyHpModel;
        private readonly IClearDataRepository _clearDataRepository;

        public StageDataUseCase(IStageDataRepository stageDataRepository, IClearDataRepository clearDataRepository)
        {
            var stageDataEntity = stageDataRepository.stageDataEntity;
            _playerEntity = new CharacterEntity(150, 5);
            _enemyEntity = new CharacterEntity(stageDataEntity.enemyHp, stageDataEntity.enemyAttack);

            _playerHpModel = new HpModel(_playerEntity.GetHp());
            _enemyHpModel = new HpModel(_enemyEntity.GetHp());

            _clearDataRepository = clearDataRepository;
        }

        public ICharacterEntity playerEntity => _playerEntity;

        public IReadOnlyReactiveProperty<int> PlayerHpModel() => _playerHpModel.HpValue;

        public void RecoverPlayer(int recoverValue)
        {
            _playerEntity.AddHp(recoverValue);
            _playerHpModel.SetHpValue(_playerEntity.GetHp());
        }

        public void DamagePlayer(int damageValue)
        {
            _playerEntity.AddHp(-damageValue);
            _playerHpModel.SetHpValue(_playerEntity.GetHp());
        }

        public bool IsAlivePlayer() => _playerEntity.GetHp() > 0;

        public ICharacterEntity enemyEntity => _enemyEntity;

        public IReadOnlyReactiveProperty<int> EnemyHpModel() => _enemyHpModel.HpValue;

        public void RecoverEnemy(int recoverValue)
        {
            _enemyEntity.AddHp(recoverValue);
            _enemyHpModel.SetHpValue(_enemyEntity.GetHp());
        }

        public void DamageEnemy(int damageValue)
        {
            _enemyEntity.AddHp(-damageValue);
            _enemyHpModel.SetHpValue(_enemyEntity.GetHp());
        }

        public bool IsAliveEnemy() => _enemyEntity.GetHp() > 0;

        public void Save() => _clearDataRepository.SaveClearData();
    }
}