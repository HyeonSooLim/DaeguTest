using TMPro;
using UnityEngine;

public class InputFieldController : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;

    private void OnEnable()
    {
        inputField.onEndEdit.AddListener((value) =>
        {
            GameEvents.InputFieldEvent.Text = value;
            MainManager.Inst.MoveToScene(SceneName.MAIN);
        });
    }

    private void OnDisable()
    {
        inputField.onValueChanged.RemoveAllListeners();
    }
}
