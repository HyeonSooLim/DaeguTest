using UnityEngine;

public class MainManager : Singleton<MainManager>
{
    public void Start()
    {
        Debug.Log("MainManager Start");
        GameEvents.GameStartTimeEvent.StartTime = System.DateTime.Now;
    }
    public void MoveToScene(SceneName sceneName)
    {
        // æ¿ ¿Ãµø
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName.ToString());
    }
}
