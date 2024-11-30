using UnityEngine;

public class TextController : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI time;
    [SerializeField] private TMPro.TextMeshProUGUI inputName;

    private void OnEnable()
    {
        EventManager.Inst.AddListener(GameEvents.GameCurrentTimeEvent, ChangeText);
        EventManager.Inst.AddListener(GameEvents.InputFieldEvent, ChangeName);
    }

    private void OnDisable()
    {
        EventManager.Inst.RemoveListener(GameEvents.GameCurrentTimeEvent);
        EventManager.Inst.RemoveListener(GameEvents.InputFieldEvent);
    }

    private void ChangeText()
    {
        this.time.text = GameEvents.GameCurrentTimeEvent.CurrentTime.ToString();
    }

    private void ChangeName()
    {
        this.inputName.text = GameEvents.InputFieldEvent.Text;
    }
}
