using UnityEngine;

public class EnterEntrance : MonoBehaviour
{
    [SerializeField] bool nextFloor;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Go to next floor
            if (nextFloor)
            {
                SceneController.Instance.getNextFloor();
            }

        }
    }
}
