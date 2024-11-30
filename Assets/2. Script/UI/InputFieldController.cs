using TMPro;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UI;

public class InputFieldController : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;

    private void OnEnable()
    {
        inputField.onEndEdit.AddListener((value) =>
        {
            GameEvents.InputFieldEvent.Text = value;
            if (value == SceneName.MAIN.ToString())
            {
                Debug.Log(value);
                MainManager.Inst.MoveToScene(SceneName.MAIN);
            }
        });
    }

    private void OnDisable()
    {
        inputField.onValueChanged.RemoveAllListeners();
    }
}
