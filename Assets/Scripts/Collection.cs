using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Collection : MonoBehaviour
{
    public List<Collectible> collection = new List<Collectible>();
    public GameObject ingredientPrefab;
    GameObject ingredientPanel;
    GameObject lastTriggered;

    void Awake()
    {
        ingredientPanel = GameObject.Find("Ingredient Panel");

        int i = 0;
        foreach (Collectible collectible in collection)
        {
            GameObject instance = Instantiate(ingredientPrefab, ingredientPanel.transform);
            instance.transform.localPosition = new Vector3(instance.transform.localPosition.x, -85 - (i * 120), 0);
            instance.GetComponent<Image>().sprite = collectible.itemSprite;
            instance.GetComponentInChildren<TextMeshProUGUI>().text = (collectible.amountNeeded > 1) ? $"{collectible.amountNeeded}" : "";
            instance.name = collectible.itemName;
            i++;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        lastTriggered = other.gameObject;
        TryCollectItem(other.gameObject.name);
    }

    void TryCollectItem(string itemName)
    {
        Collectible current = collection.Find(item => item.itemName == itemName);

        if (current != null)
        {
            if (current.amountNeeded > 0)
            {
                CollectItem(current);
            }
        }
    }

    void CollectItem(Collectible found)
    {
        found.amountNeeded--;
        GameObject instance = GameObject.Find($"Ingredient Panel/{found.itemName}");
        TextMeshProUGUI textComponent = instance.GetComponentInChildren<TextMeshProUGUI>();

        if (found.amountNeeded > 0)
        {
            textComponent.text = (found.amountNeeded > 1) ? $"{found.amountNeeded}" : "";
        }
        else
        {
            instance.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
            
            textComponent.text = "";
            textComponent.color = new Color(0, 255, 0, 1);
        }

        //lastTriggered.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
        Destroy(lastTriggered);
    }
}

[System.Serializable]
public class Collectible
{
    public string itemName;
    public int amountNeeded;
    public Sprite itemSprite;
}