using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //[SerializeField] private ReceptionBasket _receptionBasket;
    [SerializeField] private Transform _container;

    private Queue<Item> _items = new Queue<Item>();

    private float _currentCountItems = 0;

    public float CurrentCountItems => _currentCountItems;

    public Transform Container => _container;

    public void TakeItem(Item item)
    {
        _currentCountItems++;
        _items.Enqueue(item);
        item.Move(_container);
        item.SetParrentPlayer(this.gameObject);
    }
}
