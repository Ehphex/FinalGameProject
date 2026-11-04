using UnityEngine;

public class EnterEntrance : MonoBehaviour
{
    [SerializeField] private LocksManager lockManager;
    [SerializeField] bool nextFloor;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Go to next floor
            if (lockManager != null)
            {
                bool allLocksUnlocked = lockManager.CheckLocks();
                Debug.Log("Locks checked: " + allLocksUnlocked);
                if (allLocksUnlocked)
                {
                    SceneController.Instance.getNextFloor();
                }
            }

            else if (nextFloor)
            {
                SceneController.Instance.getNextFloor();
            }




        }
    }
}
