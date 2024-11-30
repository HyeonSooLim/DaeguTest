using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float Horizontal { get; private set; }
    public float Vertical { get; private set; }
    public bool Jump { get; private set; }
    public bool CameraRotate { get; private set; }
    public bool Search { get; private set; }

    [Header("Key Mapping")]
    [SerializeField] private KeyCode horizontalPositiveKey = KeyCode.D;
    [SerializeField] private KeyCode horizontalNegativeKey = KeyCode.A;
    [SerializeField] private KeyCode verticalPositiveKey = KeyCode.W;
    [SerializeField] private KeyCode verticalNegativeKey = KeyCode.S;
    [SerializeField] private KeyCode jumpKey = KeyCode.Space;
    [SerializeField] private KeyCode cameraRotationKey = KeyCode.Mouse1;
    [SerializeField] private KeyCode searchKey = KeyCode.F;

    [Header("Camera Rotation")]
    [SerializeField] private float rotationSpeed = 5f;

    private float currentYRotation = 0f;

    void Start()
    {
        if (!TryGetComponent(out CameraController _))
        {
            gameObject.AddComponent<CameraController>();
        }
    }

    void Update()
    {
        ProcessMovementInput();
        ProcessJumpInput();
        ProcessCameraRotationInput();
        ProcessSearchInput();

        if (!CameraRotate)
        {
            RotatePlayer();
        }
    }

    private void ProcessMovementInput()
    {
        Horizontal = (Input.GetKey(horizontalPositiveKey) ? 1 : 0) - (Input.GetKey(horizontalNegativeKey) ? 1 : 0);
        Vertical = (Input.GetKey(verticalPositiveKey) ? 1 : 0) - (Input.GetKey(verticalNegativeKey) ? 1 : 0);
    }

    private void ProcessJumpInput()
    {
        Jump = Input.GetKeyDown(jumpKey);
    }

    private void ProcessCameraRotationInput()
    {
        CameraRotate = Input.GetKey(cameraRotationKey);
    }

    private void ProcessSearchInput()
    {
        Search = Input.GetKeyDown(searchKey) ? true : false;
    }

    private void RotatePlayer()
    {
        float mouseX = Input.GetAxis("Mouse X");
        currentYRotation += mouseX * rotationSpeed;
        transform.rotation = Quaternion.Euler(0, currentYRotation, 0);
    }

    public void SetKeyMapping(PlayerAction action, KeyCode newKey)
    {
        switch (action)
        {
            case PlayerAction.HorizontalPositive:
                horizontalPositiveKey = newKey;
                break;
            case PlayerAction.HorizontalNegative:
                horizontalNegativeKey = newKey;
                break;
            case PlayerAction.VerticalPositive:
                verticalPositiveKey = newKey;
                break;
            case PlayerAction.VerticalNegative:
                verticalNegativeKey = newKey;
                break;
            case PlayerAction.Jump:
                jumpKey = newKey;
                break;
            default:
                Debug.LogWarning("Invalid PlayerAction provided.");
                break;
        }
    }
}
