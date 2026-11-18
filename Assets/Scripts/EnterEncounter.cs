using System;
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
            String myTag = gameObject.tag;
            if (myTag == "boss")
            {
                SceneManager.LoadScene(bossNumber, LoadSceneMode.Additive); 
                Destroy(gameObject);
            }

            if (myTag == "random")
            {
                int randNumber = UnityEngine.Random.Range(10, 13);
                SceneManager.LoadScene(randNumber, LoadSceneMode.Additive);
                Destroy(gameObject); 
            }

            if (myTag == "random2")
            {
                int randNumber = UnityEngine.Random.Range(14, 17);
                SceneManager.LoadScene(randNumber, LoadSceneMode.Additive);
                Destroy(gameObject); 
            }
            
        }
    }
}
