using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogueBox;
    public TextMeshProUGUI dialogueText;
    public string[] dialogueLines;
    private int currentLine = 0;
    public KeyCode continueKey = KeyCode.E;

    private void Start()
    {
        dialogueBox.SetActive(false);
    }

    public void StartDialogue()
    {
        dialogueBox.SetActive(true);
        currentLine = 0;
        dialogueText.text = dialogueLines[currentLine];
    }

    private void Update()
    {
        if (dialogueBox.activeSelf && Input.GetKeyDown(continueKey))
        {
            currentLine++;
            if (currentLine < dialogueLines.Length)
            {
                dialogueText.text = dialogueLines[currentLine];
            }
            else
            {
                dialogueBox.SetActive(false); // End dialogue
            }
        }
    }
}
