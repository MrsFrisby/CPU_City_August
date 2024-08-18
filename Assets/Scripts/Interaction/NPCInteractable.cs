using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteractable : MonoBehaviour
{
    [SerializeField] string interactText;

    DialogueTrigger dialogueTrigger;

    private void Start()
    {
        dialogueTrigger = GetComponent<DialogueTrigger>();
    }

    public void Interact(){
        //Debug.Log("Interact!");
        dialogueTrigger.TriggerDialogue();
    }

    public string GetInteractText()
    {
        return interactText;
    }
}
