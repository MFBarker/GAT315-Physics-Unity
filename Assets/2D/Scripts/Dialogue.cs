using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    //Source: https://www.youtube.com/watch?v=vR6H3mu_xD8
    /*** MODIFIED TO FIT NEW INPUT SYSTEM ***/

    [Header("UI")]
    [SerializeField] GameObject dialogueCanvas;
    [SerializeField] TMP_Text speakerText;
    [SerializeField] TMP_Text dialogueText;
    [SerializeField] Image portraitImage;

    [Header("Content")]
    [SerializeField] string[] speaker;
    [SerializeField] [TextArea] string[] dialogue;
    [SerializeField] Sprite[] portrait;

    [Header("Input")]
    [SerializeField] InputActionReference interactAction;

    //others
    private bool dialogueActivate = false;
    private int step = 0;

    private void Awake()
    {
        if(dialogueCanvas.activeSelf) { dialogueCanvas.SetActive(false); }
    }

    private void Update()
    {
        if (interactAction.action.WasPressedThisFrame() && interactAction.action.IsPressed()) OnPress();
    }

    public void OnPress()
    {
        print("pressed");
        if (dialogueActivate)
        {
            if (step >= speaker.Length)
            {
                dialogueCanvas.SetActive(false);
                step = 0;
            }
            else 
            {
                dialogueCanvas.SetActive(true);
                speakerText.text = speaker[step];
                dialogueText.text = dialogue[step];
                portraitImage.sprite = portrait[step];
                step++;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            dialogueActivate = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (dialogueCanvas.activeSelf) dialogueCanvas.SetActive(false);
        dialogueActivate = false;
    }
}
