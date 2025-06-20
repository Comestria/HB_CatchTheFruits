using System;
using UnityEngine;

public class MB_SpawnManager : MonoBehaviour
{
    [SerializeField] private float randomXmin, randomXmax;

    [Header("Spawn Time Values")]
    [SerializeField] private float SpawnDelay = 2f;
    [SerializeField] private float InitialDelay = 2f;
    [SerializeField] private float MinimalDelay = 0.75f;

    [Header("Generated Values for Special Elements")]
    [SerializeField] public int SpecialElementSpawn = 0;
    [SerializeField] private int MaxProbability = 7;
    [SerializeField] private int TrapSpawnNumber = 1;
    [SerializeField] private int BonusFruitSpawnNumber = 6;

    [Header("Spawning Acceleration Values")]
    [SerializeField] private int SpawnsBeforeAcceleration = 3;
    [SerializeField] private int InitialSpawnsRequired = 3;
    [SerializeField] private float acceleration = 0.25f;

    [Header("Game Elements")]
    public GameObject Fruit;
    public GameObject BonusFruit;
    public GameObject Trap;

    private void Update()
    {
        SpawnDelay -= Time.deltaTime;
        if (SpawnDelay < 0)
        {
            SpawnDelay = InitialDelay;
            Spawn();
        }
    }

    private void Spawn()
    {
        SpecialElementSpawn = UnityEngine.Random.Range(1, MaxProbability);

        for (int i = 0; i < 1; i++)
        {
            if (SpecialElementSpawn == TrapSpawnNumber)
            {
                // initiate a trap instead of a fruit
                float RandomX = UnityEngine.Random.Range(randomXmin, randomXmax);
                Vector3 RandomPosition = new Vector3(RandomX, 3.5f, 0);
                Instantiate(Trap, RandomPosition, Quaternion.identity);
            }
            else if (SpecialElementSpawn == BonusFruitSpawnNumber)
            {
                 // initiate a bonus fruit
                 float RandomX = UnityEngine.Random.Range(randomXmin, randomXmax);
                 Vector3 RandomPosition = new Vector3(RandomX, 3.5f, 0);
                 Instantiate(BonusFruit, RandomPosition, Quaternion.identity);
            } 
            else
            {
                // initiate a regular fruit
                float RandomX = UnityEngine.Random.Range(randomXmin, randomXmax);
                Vector3 RandomPosition = new Vector3(RandomX, 3.5f, 0);
                Instantiate(Fruit, RandomPosition, Quaternion.identity);
            }
        }

        if (InitialDelay > MinimalDelay)
        {
            SpawnsBeforeAcceleration -= 1;
            if (SpawnsBeforeAcceleration == 0)
            {
                InitialDelay -= acceleration;
                SpawnsBeforeAcceleration = InitialSpawnsRequired;
            }
        }
    }
}
