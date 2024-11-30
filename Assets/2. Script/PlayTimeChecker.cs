using UnityEngine;

public class PlayTimeChecker : MonoBehaviour
{
    void Start()
    {
        GameEvents.GameCurrentTimeEvent.CurrentTime = System.DateTime.Now;
        MainManager.Inst.MoveToScene(SceneName.END);
    }
}
