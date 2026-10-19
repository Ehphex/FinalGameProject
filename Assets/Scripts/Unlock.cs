using System;
using UnityEngine;

public class Unlock : MonoBehaviour
{
    [SerializeField] GameObject key;

    private bool isUnlocked = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("bluekey"))
        {
            // Unlock the door
            isUnlocked = true;
            Destroy(gameObject); // Destroy the door object
        }
    }
}
