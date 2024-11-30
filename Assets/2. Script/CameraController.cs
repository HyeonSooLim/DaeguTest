using DG.Tweening;
using Unity.Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private CinemachineInputAxisController cinemachineInputAxisController;
    [SerializeField] private CinemachineOrbitalFollow orbitalFollow;

    const float CAMERA_BACK_SPEED = 0.5f;

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
        if (!isPressed)
        {
            DOTween.To(() => orbitalFollow.HorizontalAxis.Value, x => orbitalFollow.HorizontalAxis.Value = x, 0, CAMERA_BACK_SPEED);
        }

        for (int i = 0; i < cinemachineInputAxisController.Controllers.Count; i++)
        {
            var controller = cinemachineInputAxisController.Controllers[i];
            controller.Enabled = isPressed;
        }
    }
}
