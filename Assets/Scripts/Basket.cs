using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    private Queue<Item> _items = new Queue<Item>();
    private float _offset = 0.1f;
    private float _currentOffset;
    private float _currentCountItems = 0;

    public float CurrentCountItems => _currentCountItems;

    public void AddItem(Item item)
    {
        _currentCountItems++;
        _items.Enqueue(item);

        Debug.Log(_items.Count);
    }

    public Item RevoveItem()
    {
        _currentCountItems--;
       return _items.Dequeue();
    }

    public void SortContainer()
    {
        Debug.Log(_items.Count);

        foreach (var item in _items)
        {
            item.WillMove(_offset);
        }
    }

   public Transform SetOffset(Transform pos)
   {
       pos.position = new Vector3(pos.position.x, pos.position.y + _offset, pos.position.z);

       return pos;
   }
}
