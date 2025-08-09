using System.Collections;
using UnityEngine;
using TMPro;

public class DialogManager : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject dialogBox;
    public TextMeshProUGUI dialogText;

    [Header("Dialog Settings")]
    [TextArea(3, 10)]
    public string[] lines;
    public float letterDelay = 0.03f;

    [Header("Audio")]
    public AudioClip blipSound;

    [Range(0f, 1f)]
    public float sfxVolume = 0.5f; // 👈 Control this in the Inspector

    private AudioSource audioSource;
    private int currentLine;
    private bool isTyping;
    private bool canContinue;

    void Start()
    {
        dialogBox.SetActive(false);

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();

        audioSource.playOnAwake = false;
    }

    void Update()
    {
        if (dialogBox.activeSelf && Input.GetKeyDown(KeyCode.Z))
        {
            if (isTyping)
            {
                StopAllCoroutines();
                dialogText.text = lines[currentLine];
                isTyping = false;
                canContinue = true;
            }
            else if (canContinue)
            {
                currentLine++;
                if (currentLine < lines.Length)
                {
                    StartCoroutine(TypeLine(lines[currentLine]));
                }
                else
                {
                    dialogBox.SetActive(false);
                }
            }
        }
    }

    public void StartDialog()
    {
        dialogBox.SetActive(true);
        currentLine = 0;
        StartCoroutine(TypeLine(lines[currentLine]));
    }

    IEnumerator TypeLine(string line)
    {
        dialogText.text = "";
        isTyping = true;
        canContinue = false;

        float blipCooldown = 0.05f;
        float lastBlipTime = 0f;

        foreach (char c in line)
        {
            dialogText.text += c;

            if (c != ' ' && blipSound != null && Time.time - lastBlipTime > blipCooldown)
            {
                audioSource.PlayOneShot(blipSound, sfxVolume); // 👈 use float volume here
                lastBlipTime = Time.time;
            }

            yield return new WaitForSeconds(letterDelay);
        }

        isTyping = false;
        canContinue = true;
    }
}
