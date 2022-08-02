using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private readonly float topBound = 30.0f;
    private readonly float bottomBound = -8.0f;
    private readonly float leftBound = -23.0f;
    private readonly float rightBound = 23.0f;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > topBound)
            Destroy(gameObject);

        if ((gameObject.CompareTag("Left") && transform.position.x > rightBound) ||
           (gameObject.CompareTag("Right") && transform.position.x < leftBound) ||
           (gameObject.CompareTag("Top") && transform.position.z < bottomBound))
        {
            PlayerManager.Instance.DecreaseLives();
            Debug.Log("Lives = " + PlayerManager.Instance.State.Lives);
            Destroy(gameObject);
        }
    }
}
