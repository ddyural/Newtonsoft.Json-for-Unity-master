using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class BallScoreManager : MonoBehaviour
{
    private int score = 0;
    private string jsonFilePath = "Assets/ScoreData.json";
    public string objectNameToCheck; 
    private Vector3 initialPosition; 
    public GameObject objectToClone; 
    private BallDrag bd;
    private Rigidbody rb;
    public GameObject prefabToClone;
    private bool hasCollided = true;
    

    void Start()
    {
        hasCollided = true;
        rb = GetComponent<Rigidbody>();
        initialPosition = transform.position;
        bd = GetComponent<BallDrag>();
        bd.enabled = true;
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(hasCollided);
        if (hasCollided == true)
        {
            if ((collision.gameObject.name == "Cube") || (collision.gameObject.name == objectNameToCheck))
            {
                hasCollided = false;
                Debug.Log("Проверка куб сработала");

                GameObject clone = Instantiate(prefabToClone, initialPosition, Quaternion.identity);
            }

        

            if (collision.gameObject.name == objectNameToCheck)
            {
                
                Debug.Log("Объект " + gameObject.name + " столкнулся с объектом " + objectNameToCheck + "1 проверка");

                score++;
                Debug.Log("Score: " + score);
                SaveScoreData();

            }

            // Обработка соприкосновения здесь
            Debug.Log("Соприкоснование произошло!");            
        }
        //if (collision.gameObject.name.Contains("Sphere"))
        //{
        //    Debug.Log("сработала проверка со сферой");
        //    Destroy(gameObject);
        //}

        
        //rb.useGravity = false;
        //GameObject clonedObject = Instantiate(objectToClone, initialPosition, Quaternion.identity);

        

        

        //Destroy(gameObject);

        
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Target"))
        {
            score++;
            Debug.Log("Score: " + score);
            SaveScoreData();
        }

        if (collision.gameObject.name == objectNameToCheck)
        {
            Debug.Log("Объект " + gameObject.name + " столкнулся с объектом " + objectNameToCheck);

        }
    }

    void SaveScoreData()
    {
        ScoreData data = new ScoreData(score);
        string jsonData = JsonUtility.ToJson(data);

        File.WriteAllText(jsonFilePath, jsonData);
    }

    [System.Serializable]
    public class ScoreData
    {
        public int score;

        public ScoreData(int score)
        {
            this.score = score;
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(10);
    }
}
