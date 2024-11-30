using System.Linq;
using UnityEngine;

public class Search : MonoBehaviour
{
    [SerializeField] private string targetTag = "Enemy";
    [SerializeField] private float searchRadius = 10f;
    [SerializeField] private KeyCode searchKey = KeyCode.F;
    [SerializeField] private int maxColliders = 10; // 최대 충돌체 수
    private Collider[] hitColliders;

    public event System.Action OnTargetFound;

    private void OnEnable()
    {
        EventManager.Inst.OnActionSerach += OnTargetFound;
    }

    private void OnDisable()
    {
        EventManager.Inst.OnActionSerach -= OnTargetFound;
    }

    void Start()
    {
        hitColliders = new Collider[maxColliders];
    }

    //void Update()
    //{
    //    if (Input.GetKeyDown(searchKey))
    //    {
    //        SearchForTarget();
    //    }
    //}

    public Transform FindClosestTarget(Transform origin, float searchRadius, string targetTag, int maxColliders, Collider[] hitColliders)
    {
        int numColliders = Physics.OverlapSphereNonAlloc(origin.position, searchRadius, hitColliders);
        return hitColliders.Take(numColliders)
                           .Where(collider => collider != null && collider.CompareTag(targetTag))
                           .Select(collider => collider.transform)
                           .FirstOrDefault();
    }

    public void SearchForTarget()
    {
        var target = FindClosestTarget(transform, searchRadius, targetTag, maxColliders, hitColliders);
        if (target != null)
        {
            //Debug.Log("Enemy found: " + target.name);
            OnTargetFound?.Invoke();
        }
    }
}
