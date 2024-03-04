using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Vector3 SpawnerPos;
    [SerializeField] private GameObject ball;
    private float SpawnDuration = 2f;

    public static Spawner instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        SpawnerPos = transform.position;
    }

    void SpawnNewObj()
    {
        Instantiate(ball, SpawnerPos, Quaternion.identity);
    }

    public void NewSpawnTime()
    {

        Invoke("SpawnNewObj", SpawnDuration);
    }
}
