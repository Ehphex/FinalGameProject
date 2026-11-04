using UnityEngine;

public class ChangeFrames : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite unlockedSprite;
    public Sprite lockedSprite;
    [SerializeField] private Unlock locks;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = lockedSprite;
    }

    // Update is called once per frame
    void Update()
    {
        if (locks != null && locks.isUnlocked)
        {
            spriteRenderer.sprite = unlockedSprite;
        }   
    }
}
