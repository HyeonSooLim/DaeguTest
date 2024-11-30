using UnityEngine;

public class EndSceneEvent : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI time;
    [SerializeField] private TMPro.TextMeshProUGUI inputName;
    [SerializeField] private TMPro.TextMeshProUGUI spawnCount;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        time.SetText($"PLAY TIME : {GameEvents.GameCurrentTimeEvent.PlayTime}");
        inputName.SetText($"NAME : {GameEvents.InputFieldEvent.Text}");
        spawnCount.SetText($"SPAWN COUNT : {GameEvents.EnemySpawnEvent.EnemyCount}");
    }
}
