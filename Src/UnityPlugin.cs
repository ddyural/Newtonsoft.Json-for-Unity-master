using UnityEngine;

public class Destroyer : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision != null)
        {
            Destroy(collision.gameObject, 0.5f);

        }
    }

}
