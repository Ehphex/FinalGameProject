using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

    public static SceneController Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keep the SceneController across scenes
        }
        else
        {
            Destroy(gameObject); // Ensure only one instance exists
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void getNextFloor()
    {
        // Load the next floor scene
        // You can use SceneManager.LoadScene("NextFloorSceneName") to load the next scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
