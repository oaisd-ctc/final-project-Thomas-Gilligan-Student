using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        Button play = root.Q<Button>("Play");
        Button quit = root.Q<Button>("ExitGame");
        Button mainMenu = root.Q<Button>("MainMenu");

        play.clicked += () => SceneManager.LoadScene("Tutorial");
        if (quit != null) quit.clicked += () => Application.Quit();
        if (mainMenu != null) mainMenu.clicked += () => SceneManager.LoadScene("TitleScene");
    }
}
