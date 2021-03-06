using UnityEngine.UI;
using UnityEngine;
using Zenject;
using Game.Data.Player;
using TowerGame.Data.Player;
using TowerGame.Game.Level.Units.Monsters;

namespace Game.Level.Controllers
{
    public class LevelDataController : MonoBehaviour
    {
        [SerializeField] private Text _soulsNumber;

        [Inject] PlayerData playerData;

        private int CurrentSouls;
        public int CurrentFloor;

        public int Souls;


        void Start()
        {
            FlyingEye.Dead += CounterEnemyDead;
            UpdateSoulsNumber();
        }

        public void SaveData()
        {
            playerData.data.souls += CurrentSouls;
            if (playerData.data.floorCount < CurrentFloor)
                playerData.data.floorCount = CurrentFloor;
        }

        private void CounterEnemyDead()
        {
            CurrentSouls++;
            UpdateSoulsNumber();
        }

        private void UpdateSoulsNumber()
        {
            if (_soulsNumber != null)
                _soulsNumber.text = CurrentSouls.ToString();
        }

    }
}

