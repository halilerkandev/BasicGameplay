using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            PlayerManager.Instance.IncreaseScore();
            Debug.Log("Score = " + PlayerManager.Instance.State.Score);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
