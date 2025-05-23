using UnityEngine;
using UnityEngine.SceneManagement;

public class PromptTrigger : MonoBehaviour
{
    public PromptHandler prompt;
    public string text;
    public KeyCode key = KeyCode.Space;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (prompt != null && other.gameObject.name == "Player")
        {
            if (gameObject.name == "Cookie")
            {
                bool finished = true;
                foreach (Collectible collectible in other.gameObject.GetComponent<Collection>().collection)
                {
                    if (collectible.amountNeeded > 0 && collectible.itemName != "End")
                    {
                        finished = false;
                    }
                }
                if (finished) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                else prompt.TriggerPrompt(text, key);
            }
            else
            {
                prompt.TriggerPrompt(text, key);
                Destroy(this.gameObject);
            }
        }
    }
}
