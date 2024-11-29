using Unity.Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private CinemachineInputAxisController cinemachineInputAxisController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(cinemachineInputAxisController == null)
        {
            cinemachineInputAxisController = GameObject.Instantiate(new GameObject()).AddComponent<CinemachineInputAxisController>();
        }
        else
        {
            for(int i = 0; i < cinemachineInputAxisController.Controllers.Count; i++)
            {
                cinemachineInputAxisController.Controllers[i].Enabled = false;
            }
        }
    }

    public void SetActiveCameraRotate(bool isPressed)
    {
        for (int i = 0; i < cinemachineInputAxisController.Controllers.Count; i++)
        {
            cinemachineInputAxisController.Controllers[i].Enabled = isPressed;
        }
    }
}
