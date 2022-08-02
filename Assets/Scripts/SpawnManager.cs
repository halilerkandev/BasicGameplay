using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    public float spawnRangeX = 10.0f;
    public float spawnZLimitMax = 15.0f;
    public float spawnZLimitMin = 5.0f;
    public float spawnZPos = 25.0f;
    private float spawnInterval = 5.0f;

    private readonly List<(int, string)> actionList = new();

    // Start is called before the first frame update
    void Start()
    {
        actionList.Add((0, nameof(ToRight)));
        actionList.Add((1, nameof(ToLeft)));
        actionList.Add((2, nameof(ToBottom)));

        NextSpawn();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void ToRight()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPos = new(-20, 0, Random.Range(spawnZLimitMin, spawnZLimitMax));

        GameObject animalPrefab = animalPrefabs[animalIndex];
        animalPrefab.tag = "Left";

        Instantiate(animalPrefab,
            spawnPos,
            animalPrefabs[animalIndex].transform.rotation * Quaternion.Euler(new(0, -90, 0)));

        NextSpawn();
    }

    void ToLeft()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPos = new(20, 0, Random.Range(spawnZLimitMin, spawnZLimitMax));

        GameObject animalPrefab = animalPrefabs[animalIndex];
        animalPrefab.tag = "Right";

        Instantiate(animalPrefab,
            spawnPos,
            animalPrefabs[animalIndex].transform.rotation * Quaternion.Euler(new(0, 90, 0)));

        NextSpawn();
    }

    void ToBottom()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPos = new(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnZPos);

        GameObject animalPrefab = animalPrefabs[animalIndex];
        animalPrefab.tag = "Top";

        Instantiate(animalPrefab,
            spawnPos,
            animalPrefabs[animalIndex].transform.rotation);

        NextSpawn();
    }

    void NextSpawn()
    {
        int randomIndex = Random.Range(0, actionList.Count);
        (int, string) tuple = actionList.Find(tuple => tuple.Item1 == randomIndex);
        if (tuple != (null, null))
            Invoke(tuple.Item2, spawnInterval);
    }
}
