using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        Button play = root.Q<Button>("Play");

        play.clicked += () => SceneManager.LoadScene("Game");
    }
}
