using UnityEngine;

public class BallDrag : MonoBehaviour
{
    private bool isDragging = false;
    private Rigidbody rb;
    private Camera mainCamera;
    private float speed = 1f; // Множитель скорости
    private BallDrag bd;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        bd = GetComponent<BallDrag>();
        mainCamera = Camera.main;
        rb.useGravity = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb.useGravity = true; 
            RaycastHit hit;
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
            {
                isDragging = true;
            }
        }

        if (isDragging)
        {
             
            Vector3 mousePos = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));
            rb.velocity = (mousePos - transform.position) * speed; // Используем множитель speed
        }

        if (Input.GetMouseButtonUp(0))
        {
            rb.useGravity = true;  
            bd.enabled = false;
            isDragging = false;
        }

        
    }
}
