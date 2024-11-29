using UnityEngine;

public class Zombie : Enemy
{
    // �߰� �Լ� ����
    public override void Chase(Transform target)
    {
        if (navMeshAgent != null)
        {
            navMeshAgent.SetDestination(target.position);
        }
    }
}