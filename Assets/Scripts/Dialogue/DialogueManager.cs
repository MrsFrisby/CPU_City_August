using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Cinemachine;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI actorName;
    public TextMeshProUGUI messageText;
    public RectTransform backgroundBox;

    public Animator dialogueAnimator;
    public OneWheelMovement playerController;

    public CinemachineFreeLook freeLookCamera;
    private string originalXAxisName;
    private string originalYAxisName;

    Message[] currentMessages;
    Actor[] currentActors;
    int activeMessage = 0;

    public bool inConversation = false;
    bool isWritingMessage = false;

    public float dialogueSpeed;
    private bool startAnimation = true;

    void Start()
    {
        dialogueSpeed = 0.04f;
        originalXAxisName = freeLookCamera.m_XAxis.m_InputAxisName;
        originalYAxisName = freeLookCamera.m_YAxis.m_InputAxisName;
    }

    void Update()
    {
        if (inConversation)
        {
            if (startAnimation)
            {
                dialogueAnimator.SetTrigger("Enter");
                startAnimation = false;
            }
            else
            {
                // This skips the animation if you press space
                if (isWritingMessage)
                {
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        dialogueSpeed = 0f;
                    }
                }
                else
                {
                    dialogueSpeed = 0.04f;
                }

                if (Input.GetKeyDown(KeyCode.Space) && !isWritingMessage)
                {
                    NextMessage();
                }
            }
        }
    }

    public void OpenDialogue(Message[] messages, Actor[] actors)
    {
        currentMessages = messages;
        currentActors = actors;
        activeMessage = 0;
        inConversation = true;
        playerController.allowMovement = false;
        freeLookCamera.m_XAxis.m_InputAxisName = "";
        freeLookCamera.m_YAxis.m_InputAxisName = "";

        DisplayMessage();
    }

    void DisplayMessage()
    {
        Message messageToDisplay = currentMessages[activeMessage];
        Actor actorToDisplay = currentActors[messageToDisplay.actorId];

        messageText.text = "";
        StartCoroutine(WriteSentence(messageToDisplay.message));
        actorName.text = actorToDisplay.name;

    }

    public void NextMessage()
    {
        activeMessage++;
        if(activeMessage < currentMessages.Length)
        {
            DisplayMessage();
        }
        else
        {
            inConversation = false;
            startAnimation = true;
            dialogueAnimator.SetTrigger("Exit");
            startAnimation = true;
            playerController.allowMovement = true;
            freeLookCamera.m_XAxis.m_InputAxisName = originalXAxisName;
            freeLookCamera.m_YAxis.m_InputAxisName = originalYAxisName;
        }
    }

    IEnumerator WriteSentence(string message)
    {
        isWritingMessage = true;

        foreach(char Character in message.ToCharArray())
        {
            messageText.text += Character;
            yield return new WaitForSeconds(dialogueSpeed);
        }

        isWritingMessage = false;
    }
    
}
