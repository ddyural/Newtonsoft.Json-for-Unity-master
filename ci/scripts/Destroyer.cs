using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;



public class Destroyer : MonoBehaviour
{   
    public GameObject _prefabToClone;
    public GameObject _ball; 
    private Vector3 _initialPosition; 

    void Start()
    {
        _initialPosition = new Vector3(-0.04018f, 5.65f, -8.851f);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Sphere"))
        {
            //StartCoroutine(DelayCoroutine());
            Destroy(collision.gameObject, 1.5f);
            
        }
    }

    IEnumerator DelayCoroutine()
    {
        Debug.Log("Before delay");

        yield return new WaitForSeconds(2);

        Debug.Log("After delay");
    }
}
