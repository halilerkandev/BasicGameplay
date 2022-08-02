using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hungar : MonoBehaviour
{
    public GameObject foreground;
    public int neededCarrots;
    private int currentCarrots = 0;
    private RectTransform rectTransform;

    private float posX;

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = foreground.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleHungarBarSize();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Projectile"))
        {
            if (currentCarrots != neededCarrots)
                currentCarrots++;
            if (currentCarrots == neededCarrots)
            {
                Destroy(gameObject);
            }

        }
    }

    void HandleHungarBarSize()
    {
        if (currentCarrots == 0)
            posX = 0;
        else
            posX = (currentCarrots * 100) / (neededCarrots * 2);

        rectTransform.anchoredPosition3D = new(posX, 0, 0);
        rectTransform.sizeDelta = new(posX * 2, 100);
    }
}
