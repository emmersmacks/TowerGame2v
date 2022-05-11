using UnityEngine;
using Zenject;
using Game.Data.Player.Statistic;

namespace Game.Data.Player.Installer
{
    public class PlayerStatisticInstaller : MonoInstaller
    {
        [SerializeField] private StatisticData playerStatisticData;

        public override void InstallBindings()
        {
            Container.Bind<StatisticData>().FromInstance(playerStatisticData).AsSingle();
        }
    }
}