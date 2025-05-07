using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public UIDocument pauseMenu;
    [HideInInspector] public bool isPaused;

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenu.gameObject.activeSelf)
                ResumeGame();
            else
                PauseGame();
        }
    }

    void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0.0f;
        pauseMenu.gameObject.SetActive(true);
        
        VisualElement root = pauseMenu.rootVisualElement;
        Button resume = root.Q<Button>("Resume");
        resume.clicked += () => ResumeGame();
    }

    void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1.0f;
        pauseMenu.gameObject.SetActive(false);
    }
}
