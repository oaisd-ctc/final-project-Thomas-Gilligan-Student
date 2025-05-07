using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collection : MonoBehaviour
{
    public List<Collectible> collection = new List<Collectible>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
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
    }
}


[System.Serializable]
public class Collectible
{
    public string itemName;
    public int amountNeeded;
    public Sprite itemSprite;
}