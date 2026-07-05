using UnityEngine;
using Unity.Cinemachine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private CinemachineCamera cinemachineCamera;

    [SerializeField] private Transform slingshotCenter;


    public void FollowBird(Transform bird) {
        cinemachineCamera.Follow = bird;
    }

    public void FollowSlingshot() {
        cinemachineCamera.Follow = slingshotCenter;
    }
}
