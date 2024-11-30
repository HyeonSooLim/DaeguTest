using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timeText;
    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] float endTime = 10;
    private float startTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        EventManager.Inst.BroadCast(GameEvents.InputFieldEvent);
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        GameEvents.GameCurrentTimeEvent.PlayTime = Time.time - startTime;
        EventManager.Inst.BroadCast(GameEvents.GameCurrentTimeEvent);
        if(Time.time - startTime > endTime)
        {
            MainManager.Inst.MoveToScene(SceneName.END);
        }
    }
}
