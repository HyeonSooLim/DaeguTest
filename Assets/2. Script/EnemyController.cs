using System.Linq;
using UnityEditor.Playables;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //[SerializeField] private string targetTag = "Player";
    //[SerializeField] private float searchRadius = 10f;
    //[SerializeField] private KeyCode searchKey = KeyCode.E;
    //[SerializeField] private int maxColliders = 10; // 최대 충돌체 수
    [SerializeField] private Enemy enemy;
    //private Collider[] hitColliders;
    //[SerializeField] private Search search;
    [SerializeField] private PlayerController playerController;

    void Start()
    {
        //hitColliders = new Collider[maxColliders];
        enemy = GetComponent<Enemy>();
        if(playerController == null)
            playerController = FindAnyObjectByType<PlayerController>();
        //search.OnTargetFound += () => enemy.Chase(playerController.transform);
    }
}
