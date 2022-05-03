using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;
using System.Collections;
using game.level.generation;
using Cysharp.Threading.Tasks;
using game.level.generation.factory;
using System.Threading.Tasks;

public class SwitchLevelController : MonoBehaviour
{
    [SerializeField] Transform _characterTransform;
    [SerializeField] Text _lvlCountText;
    [SerializeField] Image _switchImage;
    [SerializeField] GameObject floorPanel;

    private LevelGenerateController _levelGenerateScript;
    private GenerationSettingsCurve _generationSettingsCurve;
    private LevelDataController _dataController;

    private void Start()
    {
        _levelGenerateScript = GetComponent<LevelGenerateController>();
        _dataController = GetComponent<LevelDataController>();
        _generationSettingsCurve = GetComponent<GenerationSettingsCurve>();

        _generationSettingsCurve.GenerateDataUpdate(_dataController.CurrentFloor);
    }

    public async void ReloadGenerateLevel()
    {
        await ShowLoadScreen();
        SwitchLevelTextCount();
        _levelGenerateScript.DeleteCreatedPrefab();
        _generationSettingsCurve.GenerateDataUpdate(_dataController.CurrentFloor);
        _levelGenerateScript.GenerateNewLevel();
        _characterTransform.position = new Vector3(1.5f, 0.08897209f, -15);
        await HideLoadScreen();
        ShowFloorPanel();
    }

    public async void ShowFloorPanel()
    {
        var startPosition = floorPanel.transform.position;

        for (int count = 0; count < 20; count++)
        {
            floorPanel.transform.position = new Vector2(floorPanel.transform.position.x, floorPanel.transform.position.y - 6f);
            await Task.Delay(30);
        }
        await Task.Delay(1500);
        for (int count = 0; count < 20; count++)
        {
            floorPanel.transform.position = new Vector2(floorPanel.transform.position.x, floorPanel.transform.position.y + 6f);
            await Task.Delay(30);
        }

        floorPanel.transform.position = startPosition;
    }

    public async UniTask ShowLoadScreen()
    {
        _switchImage.DOFade(1f, 0.5f);
        await UniTask.Delay(1000);
    }

    private async UniTask HideLoadScreen()
    {
        _switchImage.DOFade(0f, 0.5f);
        await UniTask.Delay(1000);
    }

    private void SwitchLevelTextCount()
    {
        _dataController.CurrentFloor++;
        _lvlCountText.text = "Floor " + _dataController.CurrentFloor.ToString();
    }

    public void AddListener(ExitAreaScript exitScript)
    {
        exitScript.EndLevel += ReloadGenerateLevel;
    }
}
