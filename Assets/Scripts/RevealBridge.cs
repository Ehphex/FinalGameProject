using UnityEngine;

public class RevealBridge : MonoBehaviour
{
    [SerializeField] GameObject bridge;
    [SerializeField] GameObject wall;

    private SpriteRenderer spriteRenderer;

    public Sprite pressedSprite;
    public Sprite unpressedSprite;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = unpressedSprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
           bridge.SetActive(true);
           Destroy(wall);
        }     
    }
}
