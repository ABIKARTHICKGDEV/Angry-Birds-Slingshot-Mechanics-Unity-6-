using UnityEngine;
using UnityEngine.InputSystem;

public class BirdController : MonoBehaviour
{
    [SerializeField] private Transform slingshotCenter;
    [SerializeField] private float maxDragDistance = 2.0f;
    private bool isDragging = false;
    private Rigidbody2D rb;
    [SerializeField] private float launchPower = 10f;

    [SerializeField] private CameraController cameraController;

    [SerializeField] private SliceShortHandeller slingshot;
    private void Awake() {
        rb = GetComponent<Rigidbody2D>();

        rb.gravityScale = 0;
    }

    void Update()
    {
        if (isDragging)
        {
            FollowMouse();
        }
    }

    private void FollowMouse()
    {
        Vector3 mousePos =
            Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        mousePos.z = 0;

        Vector2 center = slingshotCenter.position;
        Debug.Log(center);
        Vector2 mouse = mousePos;

        float Distance = Vector2.Distance(center,mouse);

        if (Distance <= maxDragDistance) 
        {
            transform.position = mousePos;
        }
        else
        {
            Vector2 direction = (mouse - center).normalized;

            transform.position = center + direction * maxDragDistance;

        }
        
    }

    private void OnMouseDown()
    {
        isDragging = true;
        rb.bodyType = RigidbodyType2D.Kinematic;
        slingshot.StartDragging();
    }

    private void OnMouseUp()
    {
        isDragging = false;
        rb.bodyType = RigidbodyType2D.Dynamic;
        slingshot.StopDragging();
        LaunchBird();
    }
    private void OnDrawGizmos() {
        if (slingshotCenter == null)
            return;
         
           Gizmos.color = Color.red;

            Gizmos.DrawWireSphere(slingshotCenter.position, maxDragDistance);
        
    }
    private void LaunchBird() {
        Vector2 launchDirection = (Vector2)slingshotCenter.position - rb.position;
        Vector2 launchForce = launchDirection * launchPower;

        rb.gravityScale = 1;

        rb.AddForce(launchForce,ForceMode2D.Impulse);

        cameraController.FollowBird(transform);
    }
}