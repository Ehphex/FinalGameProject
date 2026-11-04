using UnityEngine;
using UnityEngine.InputSystem;

public class PlatePressed : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    public Sprite pressedSprite;
    public Sprite unpressedSprite;
    public bool isPressed = false;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Unlock the next floor
            Debug.Log("Plate Pressed!");
            isPressed = true;
            spriteRenderer.sprite = pressedSprite;
        }
    }
}
