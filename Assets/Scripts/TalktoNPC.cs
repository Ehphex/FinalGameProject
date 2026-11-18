using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Yarn.Unity;

public class TalktoNPC : MonoBehaviour
{
    [SerializeField] GameObject marker;

    [SerializeField] GameObject npc;

    [SerializeField] private DialogueRunner dialogueRunner;
    private bool canTalk = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKey(KeyCode.KeypadEnter) || Input.GetKey(KeyCode.Return) ) && canTalk)
        {
            String myTag = npc.tag;
            if(myTag == "merchant")
            {
                Debug.Log("Talking to merchant");
            // Trigger the dialogue
                dialogueRunner.StartDialogue("TalkToMerchant");
            }

            if(myTag == "tutorial")
            {
                Debug.Log("Tutorial");
            // Trigger the dialogue
                dialogueRunner.StartDialogue("Tutorial");
            }

            if(myTag == "door")
            {
                Debug.Log("Talking to door");
                dialogueRunner.StartDialogue("NewDoor");
            }

            if(myTag == "guard1")
            {
                Debug.Log("guard1");
                dialogueRunner.StartDialogue("guard1");
            }

            if(myTag == "guard2")
            {
                Debug.Log("Talking to guard2");
                dialogueRunner.StartDialogue("guard2");
            }

            if(myTag == "guard3")
            {
                Debug.Log("Talking to guard3");
                dialogueRunner.StartDialogue("guard3");
            }
  
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player talkable area!");
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
