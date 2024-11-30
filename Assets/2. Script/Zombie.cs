using UnityEngine;

public class Zombie : Enemy
{
    // 추격 함수 구현
    public override void Chase(Transform target)
    {
        if (navMeshAgent != null)
        {
            navMeshAgent.SetDestination(target.position);
        }
    }

    public override void Return()
    {
        GameManager.Inst.ReturnPool(gameObject);
    }
}
