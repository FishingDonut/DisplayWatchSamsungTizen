using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int limitItems = 1;
    public List<GameObject> items = new List<GameObject>();

    public void addItem(GameObject item)
    {
        if (items.Count < limitItems)
        {
            item.SetActive(false);
            items.Add(item);
        }
    }

    public void dropItem(int index,Vector2 spawItem)
    {
        if (index >= 0 && index < items.Count)
        {
            items[index].transform.position = spawItem;
            items[index].SetActive(true);
            items.RemoveAt(index);
        }
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
