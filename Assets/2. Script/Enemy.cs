using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public abstract class Enemy : MonoBehaviour
{
    protected NavMeshAgent navMeshAgent;

    protected virtual void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // �߰� �Լ� (�߻� �Լ�)
    public abstract void Chase(Transform target);
}
