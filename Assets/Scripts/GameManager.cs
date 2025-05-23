using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

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
            if (pauseMenu.gameObject.activeSelf) ResumeGame();
            else PauseGame();
        }
    }

    public void PauseGame(bool noMenu = false)
    {
        isPaused = true;
        Time.timeScale = 0.0f;

        if (!noMenu)
        {
            pauseMenu.gameObject.SetActive(true);
            VisualElement root = pauseMenu.rootVisualElement;
            Button resume = root.Q<Button>("Resume");
            resume.clicked += () => ResumeGame();
        }
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1.0f;
        pauseMenu.gameObject.SetActive(false);
    }
}