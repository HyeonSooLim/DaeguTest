using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private PlayerMovement playerMovement;

    // Update is called once per frame
    void Update()
    {
        playerMovement.Move(playerInput.Horizontal, playerInput.Vertical);
        playerMovement.Jump(playerInput.Jump);
    }
}
