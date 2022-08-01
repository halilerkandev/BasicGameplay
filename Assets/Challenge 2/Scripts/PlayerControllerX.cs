using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private float timeLimit = 0.5f;
    private float time = 0.0f;

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > timeLimit)
            time = timeLimit;

        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && time == timeLimit)
        {
            time = 0.0f;
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
        }
    }
}
