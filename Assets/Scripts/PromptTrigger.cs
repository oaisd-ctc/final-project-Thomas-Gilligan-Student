using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PromptTrigger : MonoBehaviour
{
    public PromptHandler prompt;
    public string text;
    public KeyCode key = KeyCode.Space;

    void Start()
    {

    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (prompt != null && other.name == "Player") prompt.TriggerPrompt(text, key);
    }
}
