using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteractable : MonoBehaviour
{
    [SerializeField] string interactText;

    DialogueTrigger dialogueTrigger;

    public DialogueManager dialogueManager;

    private GameObject container;

    public int questIndex;

    private void Start()
    {
        container = transform.Find("Canvas/PlayerInteractUI/Container")?.gameObject;
        dialogueTrigger = GetComponent<DialogueTrigger>();
    }

    public void Interact(){
        if (!dialogueManager.inConversation)
        {
            dialogueTrigger.StartDialogue(questIndex);
        }
        
    }

    public string GetInteractText()
    {
        return interactText;
    }

    public GameObject GetContainer()
    {
        return container;
    }
}
