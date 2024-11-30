using TMPro;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private TextMeshProUGUI _timeText;
    [SerializeField] private TextMeshProUGUI _nameText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        EventManager.Inst.BroadCast(GameEvents.InputFieldEvent);
    }

    // Update is called once per frame
    void Update()
    {
        EventManager.Inst.BroadCast(GameEvents.GameCurrentTimeEvent);
    }
}
