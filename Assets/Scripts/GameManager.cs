using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public UIDocument pauseMenu;
    [HideInInspector] public bool isPaused;

    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (pauseMenu.gameObject.activeSelf) ResumeGame();
            else PauseGame();
        }

        //if (Input.GetKeyDown(KeyCode.Keypad3))
        //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
            Button mainMenu = root.Q<Button>("MainMenu");
            mainMenu.clicked += () => SceneManager.LoadScene("TitleScene");
        }
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1.0f;
        pauseMenu.gameObject.SetActive(false);
    }
}