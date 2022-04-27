using UnityEngine;
using Zenject;
using game.data.player.statistic;

namespace game.data.player.installer
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