using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TurnBasedBattleManager : MonoBehaviour
{
    [Header("Combatants")]
    [SerializeField] private AttackScript player;
    [SerializeField] private AttackScript enemy;

    [Header("Buttons")]
    [SerializeField] private Button meleeButton;
    [SerializeField] private Button rangeButton;
    [SerializeField] private Button guardButton;

    [Header("Battle UI")]
    [SerializeField] private Text battleText;
    [SerializeField] private float enemyTurnDelay = 1.2f;

    private bool playerTurn = true;

    private void Start()
    {
        if (player != null && enemy != null)
        {
            player.SetTarget(enemy);
            enemy.SetTarget(player);
        }

        if (meleeButton != null)
        {
            meleeButton.onClick.AddListener(PlayerMeleeAttack);
        }

        if (rangeButton != null)
        {
            rangeButton.onClick.AddListener(PlayerRangeAttack);
        }

        if (guardButton != null)
        {
            guardButton.onClick.AddListener(PlayerGuard);
        }

        RefreshButtons();
        if (battleText != null)
        {
            battleText.text = "Your turn";
        }
    }

    public void PlayerMeleeAttack()
    {
        if (!playerTurn || player == null || enemy == null)
        {
            return;
        }

        if (!player.CanAct() || !enemy.IsAlive)
        {
            return;
        }

        player.UseMeleeAttack();
        FinishPlayerTurn();
    }

    public void PlayerRangeAttack()
    {
        if (!playerTurn || player == null || enemy == null)
        {
            return;
        }

        if (!player.CanAct() || !enemy.IsAlive)
        {
            return;
        }

        player.UseRangedAttack();
        FinishPlayerTurn();
    }

    public void PlayerGuard()
    {
        if (!playerTurn || player == null || enemy == null)
        {
            return;
        }

        if (!player.CanAct() || !enemy.IsAlive)
        {
            return;
        }

        player.Guard();
        FinishPlayerTurn();
    }

    private void FinishPlayerTurn()
    {
        if (!enemy.IsAlive)
        {
            if (battleText != null)
            {
                if (enemy.WasKilled)
                {
                    battleText.text = "Enemy was killed!";
                }
                else if (enemy.WasCaptured)
                {
                    battleText.text = "Enemy was captured!";
                }
                else
                {
                    battleText.text = "Victory!";
                }
            }
            playerTurn = false;
            RefreshButtons();
            return;
        }

        playerTurn = false;
        RefreshButtons();
        StartCoroutine(EnemyTurnRoutine());
    }

    private IEnumerator EnemyTurnRoutine()
    {
        if (battleText != null)
        {
            battleText.text = "Enemy turn";
        }

        yield return new WaitForSeconds(enemyTurnDelay);

        if (player == null || enemy == null || !player.IsAlive)
        {
            if (battleText != null)
            {
                if (player.WasKilled)
                {
                    battleText.text = "You were killed!";
                }
                else if (player.WasCaptured)
                {
                    battleText.text = "You were captured!";
                }
                else
                {
                    battleText.text = "Defeat";
                }
            }
            yield break;
        }

        int move = Random.Range(0, 3);

        if (move == 0)
        {
            enemy.UseMeleeAttack();
        }
        else if (move == 1)
        {
            enemy.UseRangedAttack();
        }
        else
        {
            enemy.Guard();
        }

        if (!player.IsAlive)
        {
            if (battleText != null)
            {
                if (player.WasKilled)
                {
                    battleText.text = "You were killed!";
                }
                else if (player.WasCaptured)
                {
                    battleText.text = "You were captured!";
                }
                else
                {
                    battleText.text = "Defeat";
                }
            }
            playerTurn = false;
            RefreshButtons();
            yield break;
        }

        playerTurn = true;
        if (battleText != null)
        {
            battleText.text = "Your turn";
        }
        RefreshButtons();
    }

    private void RefreshButtons()
    {
        bool canUseButtons = playerTurn && player != null && enemy != null && player.IsAlive && enemy.IsAlive;

        if (meleeButton != null)
        {
            meleeButton.interactable = canUseButtons;
        }

        if (rangeButton != null)
        {
            rangeButton.interactable = canUseButtons;
        }

        if (guardButton != null)
        {
            guardButton.interactable = canUseButtons;
        }
    }
}
