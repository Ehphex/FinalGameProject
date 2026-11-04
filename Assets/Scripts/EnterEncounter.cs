using UnityEngine;

public class EnterEncounter : MonoBehaviour
{
    [SerializeField] private bool isTouching;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
   
            SceneController.Instance.LoadScene("Pokemon 1"); // Load the encounter scene
        }
    }
}
