using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    private float spawnLimitXLeft = -9;
    private float spawnLimitXRight = 7;
    private float spawnPosY = 15;

    private float startDelay = 1.0f;
    private float spawnIntervalMin = 3.0f;
    private float spawnIntervalMax = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(SpawnRandomBall), Random.Range(spawnIntervalMin, spawnIntervalMax));
    }

    // Spawn random ball at random x position at top of play area
    void SpawnRandomBall()
    {

        // Generate random ball index and random spawn position
        int randomBallIndex = Random.Range(0, ballPrefabs.Length);
        Vector3 spawnPos = new(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);

        // instantiate ball at random spawn location
        Instantiate(ballPrefabs[randomBallIndex], spawnPos, ballPrefabs[randomBallIndex].transform.rotation);

        Invoke(nameof(SpawnRandomBall), Random.Range(spawnIntervalMin, spawnIntervalMax));
    }

}
