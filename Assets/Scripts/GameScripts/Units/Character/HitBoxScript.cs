using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using Zenject;
using game.data.player;
using UnityEngine.UI;
using System.Threading.Tasks;
using TMPro;

public class HitBoxScript : MonoBehaviour
{
    [SerializeField] GameObject damageNumberPrefab;

    public int damage;

    HealthController monsterHealth;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision != null)
        {
            if (collision.transform.GetComponent<Monsters>())
            {
                monsterHealth = collision.transform.GetComponent<HealthController>();
                monsterHealth.GetDamage(damage);
                SpawnDamageNumber();
            }
        }
    }

    private async void SpawnDamageNumber()
    {
        var obj = Instantiate(damageNumberPrefab, transform.position, Quaternion.identity);
        //не работает
        //var damage = playerData.data.damage;
        obj.GetComponentInChildren<TextMeshProUGUI>().text = damage.ToString();
        await Task.Delay(1000);
        Destroy(obj);
    }
}
