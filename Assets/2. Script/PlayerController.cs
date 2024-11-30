using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private CameraController cameraController;
    [SerializeField] private Search search;

    private IPlayerState _currentState;
    private IdleState _idleState = new IdleState();
    private MoveState _moveState = new MoveState();
    private JumpState _jumpState = new JumpState();

    void Start()
    {
        SetState(_idleState);
    }

    void Update()
    {
        _currentState?.Stay(this);

        playerMovement.Move(playerInput.Horizontal, playerInput.Vertical);
        playerMovement.Jump(playerInput.Jump);
        cameraController.SetActiveCameraRotate(playerInput.CameraRotate);
        Search();
        HandleStateTransitions();
    }

    public void SetState(IPlayerState newState)
    {
        _currentState?.Exit(this);
        _currentState = newState;
        _currentState.Enter(this);
    }

    private void HandleStateTransitions()
    {
        if (playerInput.Jump)
        {
            SetState(_jumpState);
        }
        else if (playerInput.Horizontal != 0 || playerInput.Vertical != 0)
        {
            SetState(_moveState);
        }
        else
        {
            SetState(_idleState);
        }
    }

    private void Search()
    {
        if (playerInput.Search)
        {
            //EventManager.Inst.
            Debug.Log("Search");
        }
    }
}
