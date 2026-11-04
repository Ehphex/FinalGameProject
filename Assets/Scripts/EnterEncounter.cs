using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterEncounter : MonoBehaviour
{
    [SerializeField] private bool isTouching;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
   
           SceneManager.LoadScene("Pokemon 3", LoadSceneMode.Additive); // Load the encounter scene
        }
    }
}
