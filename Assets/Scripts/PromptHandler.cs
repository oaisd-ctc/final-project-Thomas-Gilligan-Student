using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PromptHandler : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI promptText;
    [SerializeField] TextMeshProUGUI continueText;
    [SerializeField] KeyCode triggerKey = KeyCode.Space;
    public GameManager gameManager;

    void Start()
    {

    }

    void Update()
    {
        if (gameObject.activeSelf)
        {
            if (Input.GetKeyDown(triggerKey))
            {
                gameObject.SetActive(false);
                triggerKey = KeyCode.Space;

                gameManager.ResumeGame();
            }
        }
    }

    public void TriggerPrompt(string text, KeyCode key)
    {
        if (promptText != null && continueText != null)
        {
            gameObject.SetActive(true);
            promptText.text = text;
            continueText.text = "Press " + key + " to Continue";
            triggerKey = key;
            
            gameManager.PauseGame(true);
        }
    }
}
