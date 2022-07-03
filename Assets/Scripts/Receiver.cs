using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Receiver : MonoBehaviour
{
    [SerializeField] private Transform _marshrut;
    [SerializeField] private Basket _receptionBasket;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Item item))
        {
            Debug.Log("Итем в коллайдере");
            _receptionBasket.AddItem(item);
            item.Move(_receptionBasket.SetOffset(_marshrut));
        }
    }
}
