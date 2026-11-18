using Unity.Cinemachine;
using UnityEngine;

public class ShowTiles : MonoBehaviour
{
    public GameObject[] greenTiles;

    private SpriteRenderer spriteRenderer;

    public Sprite pressedSprite;
    public Sprite unpressedSprite;

    public float alpha = 0.0f;

    public CinemachineCamera vcam;
    public float zoomedOut;
    public float zoomSpeed;
    private float defaultSize;

    private float targetsize;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = unpressedSprite;

        if (vcam != null)
        {
            defaultSize = vcam.Lens.OrthographicSize;
            targetsize = defaultSize;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (vcam != null)
        {
            vcam.Lens.OrthographicSize = Mathf.Lerp(vcam.Lens.OrthographicSize,targetsize,Time.deltaTime * zoomSpeed);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
           targetsize = zoomedOut;
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
           targetsize = defaultSize;
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
