using System; 
using UnityEngine;

public class Unlock : MonoBehaviour
{
    [SerializeField] private FollowPlayer key;
    [SerializeField] private PlatePressed locker;
    public bool isUnlocked = false; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }
     

    // Update is called once per frame
    void Update()
    {
        if (locker != null && locker.isPressed)
        {
            isUnlocked = true;
            Debug.Log("Unlocked the next floor!");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Unlock the next floor
            if (key != null && key.isCollected)
            {
                isUnlocked = true;
                Debug.Log("Unlocked the next floor!");
                Destroy(key.gameObject);
            }
        }
    }
}
