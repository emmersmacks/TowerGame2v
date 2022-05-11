using UnityEngine;
using Zenject;
using Game.Data.Player;
using TowerGame.Data.Player;

namespace Game.Data.Player.Installer
{
    public class PlayerDataInstaller : MonoInstaller
    {
        [SerializeField] private PlayerData playerData;

        public override void InstallBindings()
        {
            Container.Bind<PlayerData>().FromInstance(playerData).AsSingle();
        }
    }
}
