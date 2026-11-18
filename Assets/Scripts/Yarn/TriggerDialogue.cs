using UnityEngine;
using Yarn.Unity;

public class TriggerDialogue : MonoBehaviour
{
    [SerializeField] private DialogueRunner dialogueRunner;
    [SerializeField] private bool isTalking;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        if (isTalking)
        {
            dialogueRunner.StartDialogue("TalktoMerchant");
        }
    }
}
