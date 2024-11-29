using UnityEngine;

public enum PlayerAction
{
    HorizontalPositive,
    HorizontalNegative,
    VerticalPositive,
    VerticalNegative,
    Jump
}

public class PlayerInput : MonoBehaviour
{
    public float Horizontal { get; private set; }
    public float Vertical { get; private set; }
    public bool Jump { get; private set; }
    public bool CameraRotate { get; private set; }

    [SerializeField] private KeyCode horizontalPositiveKey = KeyCode.D;
    [SerializeField] private KeyCode horizontalNegativeKey = KeyCode.A;
    [SerializeField] private KeyCode verticalPositiveKey = KeyCode.W;
    [SerializeField] private KeyCode verticalNegativeKey = KeyCode.S;
    [SerializeField] private KeyCode jumpKey = KeyCode.Space;
    [SerializeField] private KeyCode cameraRotationKey = KeyCode.Mouse1;

    void Start()
    {
        if (TryGetComponent<CameraController>(out CameraController controller) == false)
        {
            gameObject.AddComponent<CameraController>();
        }
    }

    void Update()
    {
        Horizontal = 0;
        Vertical = 0;

        if (Input.GetKey(horizontalPositiveKey))
        {
            Horizontal += 1;
        }
        if (Input.GetKey(horizontalNegativeKey))
        {
            Horizontal -= 1;
        }
        if (Input.GetKey(verticalPositiveKey))
        {
            Vertical += 1;
        }
        if (Input.GetKey(verticalNegativeKey))
        {
            Vertical -= 1;
        }

        CameraRotate = Input.GetKey(cameraRotationKey);
        Jump = Input.GetKeyDown(jumpKey);
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
        }
    }
}
