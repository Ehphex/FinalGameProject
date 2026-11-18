using UnityEngine;

public class ShowTiles : MonoBehaviour
{
    public GameObject[] greenTiles;

    private SpriteRenderer spriteRenderer;

    public Sprite pressedSprite;
    public Sprite unpressedSprite;

    public float alpha = 0.0f;
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
           
           foreach (GameObject tile in greenTiles)
            {
                SpriteRenderer sprite = tile.GetComponent<SpriteRenderer>();

                Color newColor = sprite.color;
                alpha = 1f;
                newColor.a = alpha;
                sprite.color = newColor;
                spriteRenderer.sprite = pressedSprite;
            }
        }     
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
           
           foreach (GameObject tile in greenTiles)
            {
                SpriteRenderer sprite = tile.GetComponent<SpriteRenderer>();

                Color newColor = sprite.color;
                alpha = 0.0f;
                newColor.a = alpha;
                sprite.color = newColor;
                spriteRenderer.sprite = unpressedSprite;
                
            }
        }     
    }
}
