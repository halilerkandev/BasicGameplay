using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 10.0f;
    public float xRange = 10.0f;

    public GameObject projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(horizontalInput * speed * Time.deltaTime * Vector3.right);

        if (transform.position.x < -xRange)
            transform.position = new(-xRange, transform.position.y, transform.position.z);

        if (transform.position.x > xRange)
            transform.position = new(xRange, transform.position.y, transform.position.z);

        if (Input.GetKeyDown(KeyCode.Space))
            // Launch a projectile from the player
            Instantiate(projectilePrefab, transform.position + Vector3.forward * 1.2f, projectilePrefab.transform.rotation);
    }
}
