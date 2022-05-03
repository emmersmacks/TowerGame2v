using UnityEngine.UI;
using UnityEngine;
using Zenject;
using game.data.player;

public class ShowData : MonoBehaviour
{
    [SerializeField] private Text _recordFloorText;
    [SerializeField] private Text _soulsText;
    [SerializeField] private Text _moneyText;


    [Inject] PlayerData playerData;

    void Start()
    {
        SetDataValue();
    }

    public void SetDataValue()
    {
        if(_recordFloorText != null)
            _recordFloorText.text = playerData.data.floorCount.ToString();

        if (_moneyText != null)
            _moneyText.text = playerData.data.money.ToString();

        _soulsText.text = playerData.data.souls.ToString();
        
    }
}
