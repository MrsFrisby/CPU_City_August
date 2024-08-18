using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInteractUI : MonoBehaviour
{
    [SerializeField] GameObject containerGameObject;
    [SerializeField] PlayerInteract playerInteract;
    [SerializeField] TextMeshProUGUI interactTextMeshPro;

    void Update()
    {
        if(playerInteract.GetInteractableObject() != null)
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
        interactTextMeshPro.text = npcInteractable.GetInteractText();
        containerGameObject.SetActive(true);
    }

    void Hide()
    {
        containerGameObject.SetActive(false);
    }
}
