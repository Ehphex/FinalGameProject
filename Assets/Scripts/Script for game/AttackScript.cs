using UnityEngine;
using UnityEngine.UI;

public class AttackScript : MonoBehaviour
{
    public enum AttackType
    {
        Melee,
        Ranged
    }

    [Header("Combat Setup")]
    [SerializeField] private bool isPlayer = true;
    [SerializeField] private int maxMeleeHealth = 100;
    [SerializeField] private int maxRangeHealth = 80;
    [SerializeField] private int meleeDamage = 12;
    [SerializeField] private int rangeDamage = 10;
    [SerializeField] private float guardReduction = 0.5f;

    [Header("Targeting")]
    [SerializeField] private AttackScript enemyTarget;

    [Header("UI Bars")]
    [SerializeField] private Slider meleeHealthSlider;
    [SerializeField] private Slider rangeHealthSlider;

    private int currentMeleeHealth;
    private int currentRangeHealth;
    private bool isAlive = true;
    private bool guarding;
    private bool wasKilled;
    private bool wasCaptured;

    public bool IsPlayer => isPlayer;
    public bool IsAlive => isAlive;
    public bool WasKilled => wasKilled;
    public bool WasCaptured => wasCaptured;

    private void Awake()
    {
        ResetCombatStats();
    }

    public void ResetCombatStats()
    {
        currentMeleeHealth = maxMeleeHealth;
        currentRangeHealth = maxRangeHealth;
        isAlive = true;
        guarding = false;
        wasKilled = false;
        wasCaptured = false;
        RefreshHealthUI();
    }

    public void SetTarget(AttackScript target)
    {
        enemyTarget = target;
    }

    public bool CanAct()
    {
        return isAlive && enemyTarget != null && enemyTarget.IsAlive;
    }

    public void UseMeleeAttack()
    {
        if (!CanAct())
        {
            return;
        }

        enemyTarget.TakeDamage(AttackType.Melee, meleeDamage, this);
        Debug.Log(gameObject.name + " uses Melee attack for " + meleeDamage + " damage.");
    }

    public void UseRangedAttack()
    {
        if (!CanAct())
        {
            return;
        }

        enemyTarget.TakeDamage(AttackType.Ranged, rangeDamage, this);
        Debug.Log(gameObject.name + " uses Range attack for " + rangeDamage + " damage.");
    }

    public void Guard()
    {
        guarding = true;
        Debug.Log(gameObject.name + " guards and reduces incoming damage.");
    }

    public void TakeDamage(AttackType type, int amount, AttackScript attacker)
    {
        if (!isAlive)
        {
            return;
        }

        int finalAmount = amount;
        if (guarding)
        {
            finalAmount = Mathf.RoundToInt(amount * (1f - guardReduction));
            guarding = false;
        }

        if (type == AttackType.Melee)
        {
            currentMeleeHealth = Mathf.Clamp(currentMeleeHealth - finalAmount, 0, maxMeleeHealth);
            Debug.Log(gameObject.name + " melee health = " + currentMeleeHealth + "/" + maxMeleeHealth + " after " + amount + " damage.");

            if (currentMeleeHealth <= 0)
            {
                wasKilled = true;
                wasCaptured = false;
                isAlive = false;
                Debug.Log(gameObject.name + " was killed.");
            }
        }
        else
        {
            currentRangeHealth = Mathf.Clamp(currentRangeHealth - finalAmount, 0, maxRangeHealth);
            Debug.Log(gameObject.name + " range health = " + currentRangeHealth + "/" + maxRangeHealth + " after " + amount + " damage.");

            if (currentRangeHealth <= 0)
            {
                wasCaptured = true;
                wasKilled = false;
                isAlive = false;
                Debug.Log(gameObject.name + " was captured.");
            }
        }

        RefreshHealthUI();
    }

    private void RefreshHealthUI()
    {
        if (meleeHealthSlider != null)
        {
            meleeHealthSlider.maxValue = maxMeleeHealth;
            meleeHealthSlider.value = currentMeleeHealth;
        }

        if (rangeHealthSlider != null)
        {
            rangeHealthSlider.maxValue = maxRangeHealth;
            rangeHealthSlider.value = currentRangeHealth;
        }
    }
}
