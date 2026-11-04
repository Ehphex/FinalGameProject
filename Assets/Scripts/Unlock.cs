using System; 
using UnityEngine;

public class Unlock : MonoBehaviour
{
    [SerializeField] private FollowPlayer key;
    [SerializeField] private PlatePressed locker;

    private SpriteRenderer spriteRenderer;

    public Sprite unlockedSprite;
    public Sprite lockedSprite;
    public bool isUnlocked = false; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = lockedSprite;
    }
     

    // Update is called once per frame
    void Update()
    {
        if (locker != null && locker.isPressed)
        {
            isUnlocked = true;
            spriteRenderer.sprite = unlockedSprite;
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
