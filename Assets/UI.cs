using UnityEngine;
using UnityEngine.UIElements;

public class UI : MonoBehaviour
{
    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        Button newGame = root.Q<Button>("NewGame");

        newGame.clicked += () => Debug.Log("clicked");
    }
}
