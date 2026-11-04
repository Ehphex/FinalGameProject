using UnityEngine;

public class FighterAction : MonoBehaviour
{
    private AttackScript playerCombat;
    private AttackScript enemyCombat;

    private void Awake()
    {
        GameObject hero = GameObject.FindGameObjectWithTag("Hero");
        GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");

        if (hero != null)
        {
            playerCombat = hero.GetComponent<AttackScript>();
        }

        if (enemy != null)
        {
            enemyCombat = enemy.GetComponent<AttackScript>();
        }

        if (playerCombat != null && enemyCombat != null)
        {
            playerCombat.SetTarget(enemyCombat);
            enemyCombat.SetTarget(playerCombat);
        }
    }

    public void SelectAttack(string btn)
    {
        SelectAttacks(btn);
    }

    public void SelectAttacks(string btn)
    {
        AttackScript attacker = GetComponent<AttackScript>();
        if (attacker == null)
        {
            return;
        }

        if (btn == "melee")
        {
            attacker.UseMeleeAttack();
        }
        else if (btn == "range")
        {
            attacker.UseRangedAttack();
        }
        else if (btn == "guard")
        {
            attacker.Guard();
        }
        else
        {
            Debug.Log("Unknown move: " + btn);
        }
    }
}