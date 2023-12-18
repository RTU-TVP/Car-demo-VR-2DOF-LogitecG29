using UnityEngine;
using UnityEngine.SceneManagement;

public class Bootstrap : MonoBehaviour
{
    private void Start()
    {
        SceneManager.LoadSceneAsync("Gameplay");
        QualitySettings.vSyncCount = 1;
        Application.targetFrameRate = 120;
    }
}