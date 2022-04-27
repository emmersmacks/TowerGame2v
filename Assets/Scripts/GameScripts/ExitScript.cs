using UnityEngine.SceneManagement;
using UnityEngine;


public class ExitScript : MonoBehaviour
{
    [SerializeField] private LevelDataController _dataController;

    public void ExitInMenu()
    {
        Time.timeScale = 1;
        _dataController.SaveData();
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
