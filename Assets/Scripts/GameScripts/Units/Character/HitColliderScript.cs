using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using Zenject;
using Game.Data.Player;
using UnityEngine.UI;
using System.Threading.Tasks;
using TMPro;
using Cysharp.Threading.Tasks;
using TowerGame.Game.Level.Units.Monsters;

namespace TowerGame.Game.Level.Units.Character
{
    public class HitColliderScript : MonoBehaviour
    {
        [SerializeField] GameObject damageNumberPrefab;

        public int damage;

        HealthController monsterHealth;

        private async void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision != null)
            {
                if (collision.transform.GetComponent<MonsterScript>())
                {
                    monsterHealth = collision.transform.GetComponent<HealthController>();
                    monsterHealth.GetDamage(damage);
                    await SpawnDamageNumber();
                }
            }
        }

        private async UniTask SpawnDamageNumber()
        {
            var obj = Instantiate(damageNumberPrefab, transform.position, Quaternion.identity);
            //не работает
            //var damage = playerData.data.damage;
            obj.GetComponentInChildren<TextMeshProUGUI>().text = damage.ToString();
            await Task.Delay(1000);
            Destroy(obj);
        }
    }
}

