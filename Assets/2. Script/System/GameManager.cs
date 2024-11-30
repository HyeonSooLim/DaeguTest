using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private GameObjectPool enemyPool;
    [SerializeField] private int enemyCount = 10;
    [SerializeField] private Vector3 spawnAreaMin;
    [SerializeField] private Vector3 spawnAreaMax;

    void Awake()
    {
        Debug.Log("GameManager Awake");
        GameSetting();
        SpawnEnemies();
    }

    void GameSetting()
    {
        Application.targetFrameRate = 60;
    }

    void SpawnEnemies()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            Vector3 randomPosition = GetRandomPosition();
            GameObject enemy = enemyPool.GetObject();
            enemy.transform.position = randomPosition;
        }
    }

    Vector3 GetRandomPosition()
    {
        float x = Random.Range(spawnAreaMin.x, spawnAreaMax.x);
        float z = Random.Range(spawnAreaMin.z, spawnAreaMax.z);
        float y = 0.5f;
        return new Vector3(x, y, z);
    }

    public void ReturnPool(GameObject gameObject)
    {
        enemyPool.ReturnObject(gameObject);
    }
}
