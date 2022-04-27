using UnityEngine;
using Zenject;
using game.data.player;

namespace game.data.player.installer
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
