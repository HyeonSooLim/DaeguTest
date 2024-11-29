using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private CameraController cameraController;

    // Update is called once per frame
    void Update()
    {
        playerMovement.Move(playerInput.Horizontal, playerInput.Vertical);
        playerMovement.Jump(playerInput.Jump);
        cameraController.SetActiveCameraRotate(playerInput.CameraRotate);
    }
}
