using NUnit.Framework;
using UnityEngine;

public class TouchTileRed : MonoBehaviour
{
    [SerializeField] private float hiddenAlpha = 0.0f;
    private SpriteRenderer spriteRenderer;

    private bool isOpaque = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        Color color = spriteRenderer.color;
        color.a = hiddenAlpha;
        spriteRenderer.color = color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        string myTag = gameObject.tag;

        if (other.CompareTag("Player"))
        {
            Color color = spriteRenderer.color;
            color.a = 1f;
            spriteRenderer.color = color;
            isOpaque = false;
        }        
    }
}
