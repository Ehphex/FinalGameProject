using UnityEngine;
using UnityEngine.SceneManagement;
using Yarn.Unity;

public class TalktoNPC : MonoBehaviour
{
    [SerializeField] GameObject marker;

    [SerializeField] private DialogueRunner dialogueRunner;
    private bool canTalk = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.KeypadEnter) && canTalk)
        {
            Debug.Log("Talking to merchant");
            // Trigger the dialogue
            dialogueRunner.StartDialogue("TalkToMerchant");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered merchant area!");
            marker.SetActive(true);
            canTalk = true;

        }

        else
        {
            marker.SetActive(false);
            canTalk = false;
        }
    }
}
