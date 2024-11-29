using System.Linq;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private string targetTag = "Player";
    [SerializeField] private float searchRadius = 10f;
    [SerializeField] private KeyCode searchKey = KeyCode.E;
    [SerializeField] private int maxColliders = 10; // 최대 충돌체 수
    [SerializeField] private Enemy enemy;
    private Collider[] hitColliders;

    void Start()
    {
        hitColliders = new Collider[maxColliders];
        enemy = GetComponent<Enemy>();
    }

    void Update()
    {
        if (Input.GetKeyDown(searchKey))
        {
            SearchForTarget();
        }
    }

    private void SearchForTarget()
    {
        int numColliders = Physics.OverlapSphereNonAlloc(transform.position, searchRadius, hitColliders);
        var target = hitColliders.Take(numColliders)
                                 .Where(collider => collider != null && collider.CompareTag(targetTag))
                                 .Select(collider => collider.transform)
                                 .FirstOrDefault();

        if (target != null)
        {
            ChaseTarget(target);
        }
    }

    private void ChaseTarget(Transform target)
    {
        enemy.Chase(target);
    }
}