using UnityEngine;

[CreateAssetMenu(fileName = "New Item")]

public class ItemSO : ScriptableObject
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public string itemName;
    [TextArea] public string itemDescription;

    public Sprite icon;

    public bool isGold;
    
    [Header("Stats")]
    public int damage;
    public int shots;

    public int cooldown;

    public float evadePercent;
    public int currentHealth;
}
