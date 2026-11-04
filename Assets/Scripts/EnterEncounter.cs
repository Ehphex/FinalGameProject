using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterEncounter : MonoBehaviour
{
    public int bossNumber;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered encounter area!");
        
            SceneManager.LoadScene(bossNumber - 1, LoadSceneMode.Additive); // Load the encounter scene
            Destroy(gameObject);
        }
    }
}
