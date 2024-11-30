using UnityEngine;

public class EndSceneEvent : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        EventManager.Inst.AddListener(GameEvents.ShowPlayTimeAndSceneNameEvent, ShowSceneNameAndTime);
    }

    void OnDisable()
    {
        EventManager.Inst.RemoveListener(GameEvents.ShowPlayTimeAndSceneNameEvent);
    }

    private void ShowSceneNameAndTime()
    {
        Debug.Log("SceneName: " + UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        Debug.Log("InputFieldText: " + GameEvents.InputFieldEvent.Text);
        Debug.Log("PlayTime: " + (GameEvents.GameCurrentTimeEvent.CurrentTime - GameEvents.GameStartTimeEvent.StartTime).ToString());
        MainManager.Inst.MoveToScene(SceneName.LOBBY);
    }

    public void OnClickButton()
    {
        EventManager.Inst.BroadCast(GameEvents.ShowPlayTimeAndSceneNameEvent);
    }
}
