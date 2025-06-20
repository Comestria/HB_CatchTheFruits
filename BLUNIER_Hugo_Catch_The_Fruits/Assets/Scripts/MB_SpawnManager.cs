using UnityEngine;

public class MB_SpawnManager : MonoBehaviour
{
    [SerializeField] private float randomXmin, randomXmax;
    [SerializeField] private float SpawnDelay = 2f;
    public GameObject Fruit;
    public GameObject Trap;

    private void Update()
    {
        SpawnDelay -= Time.deltaTime;
        if (SpawnDelay < 0)
        {
            SpawnDelay = 3f;
            Spawn();
        }
    }

    private void Spawn()
    {
        for (int i = 0; i < 1; i++)
        {
            float RandomX = UnityEngine.Random.Range(randomXmin, randomXmax);
            Vector3 RandomPosition = new Vector3(RandomX, 3.5f, 0);
            Instantiate(Fruit, RandomPosition, Quaternion.identity);
        }
    }
}
