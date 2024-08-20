using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInteractUI : MonoBehaviour
{
    [SerializeField] GameObject containerGameObject;
    [SerializeField] PlayerInteract playerInteract;
    [SerializeField] TextMeshProUGUI interactTextMeshPro;  

    public DialogueManager dialogueManager;

    void Update()
    {
        if(playerInteract.GetInteractableObject() != null && !dialogueManager.inConversation)
        {
            Show(playerInteract.GetInteractableObject());
        }
        else
        {
            Hide();
        }
    }


    void Show(NPCInteractable npcInteractable)
    {
        GameObject container = npcInteractable.GetContainer();
        interactTextMeshPro.text = npcInteractable.GetInteractText();
        container.SetActive(true);
    }

    void Hide()
    {
        containerGameObject.SetActive(false);
    }

    GameObject FindDeepChild(Transform parent, string name)
    {
        foreach (Transform child in parent)
        {
            if (child.name == name)
            {
                return child.gameObject;
            }

            GameObject found = FindDeepChild(child, name);
            if (found != null)
            {
                return found;
            }
        }

        return null;
    }
}

