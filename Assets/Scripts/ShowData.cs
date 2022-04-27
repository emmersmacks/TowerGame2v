using UnityEngine.UI;
using UnityEngine;
using Zenject;
using game.data.player;

public class ShowData : MonoBehaviour
{
    [SerializeField] private Text _recordFloorText;
    [SerializeField] private Text _soulsText;

    [Inject] PlayerData playerData;

    void Start()
    {
        SetDataValue();
    }

    public void SetDataValue()
    {
        int currentSouls = playerData.data.souls;
        int currentFloorRecord = playerData.data.floorCount;

        _recordFloorText.text = currentFloorRecord.ToString();
        _soulsText.text = currentSouls.ToString();

    }
}
