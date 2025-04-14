using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        Button newGame = root.Q<Button>("NewGame");

        newGame.clicked += () => SceneManager.LoadScene("Game");
    }
}
