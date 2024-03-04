using UnityEngine;

public class DragAndShoot : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 dragStartPosition;
    private Vector3 dragEndPosition;
    private Vector3 shootDirection;
    private float dragStartTime;
    private float dragEndTime;
    private float maxShootSpeed = 10f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnMouseDown()
    {
        rb.useGravity = true;
        dragStartPosition = Input.mousePosition;
        dragStartTime = Time.time;
    }

    void OnMouseUp()
    {
        rb.useGravity = true;
        dragEndPosition = Input.mousePosition;
        dragEndTime = Time.time;

        CalculateShootDirection();
        ShootBall();
    }

    void CalculateShootDirection()
    {
        shootDirection = (dragEndPosition - dragStartPosition).normalized;
    }

    void ShootBall()
    {
        rb.useGravity = true;
        float dragDuration = dragEndTime - dragStartTime;
        float dragDistance = Vector3.Distance(dragEndPosition, dragStartPosition);
        float shootSpeed = Mathf.Clamp(dragDistance / dragDuration, 0f, maxShootSpeed);

        rb.AddForce(new Vector3(shootDirection.x * shootSpeed, shootDirection.y * shootSpeed, shootSpeed), ForceMode.Impulse);

        Spawner.instance.NewSpawnTime();

    }
}