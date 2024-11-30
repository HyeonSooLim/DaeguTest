using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private CameraController cameraController;

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

        HandleStateTransitions();
    }

    public void SetState(IPlayerState newState)
    {
        if (_currentState == newState) return;
        _currentState?.Exit(this);
        _currentState = newState;
        _currentState.Enter(this);
    }

    private void HandleStateTransitions()
    {
        switch (playerInput)
        {
            case var input when input.Jump:
                SetState(_jumpState);
                break;
            case var input when input.Horizontal != 0 || input.Vertical != 0:
                SetState(_moveState);
                break;
            default:
                SetState(_idleState);
                break;
        }
    }
}
