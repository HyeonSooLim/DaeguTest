
using UnityEngine;

public interface IPlayerState
{
    void Enter(PlayerController player);
    void Stay(PlayerController player);
    void Exit(PlayerController player);
}

public class IdleState : IPlayerState
{
    public void Enter(PlayerController player)
    {
        Debug.Log("Player entered Idle state.");
    }

    public void Stay(PlayerController player)
    {
        Debug.Log("Player is idle.");
    }

    public void Exit(PlayerController player)
    {
        Debug.Log("Player exited Idle state.");
    }
}

public class MoveState : IPlayerState
{
    public void Enter(PlayerController player)
    {
        Debug.Log("Player entered Move state.");
    }

    public void Stay(PlayerController player)
    {
        Debug.Log("Player is Moving.");
    }

    public void Exit(PlayerController player)
    {
        Debug.Log("Player exited Move state.");
    }
}

public class JumpState : IPlayerState
{
    public void Enter(PlayerController player)
    {
        Debug.Log("Player entered Jump state.");
    }

    public void Stay(PlayerController player)
    {
        Debug.Log("Player is Jumping.");
    }

    public void Exit(PlayerController player)
    {
        Debug.Log("Player exited Jump state.");
    }
}
