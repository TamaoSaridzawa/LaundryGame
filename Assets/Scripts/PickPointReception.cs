using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickPointReception : MonoBehaviour
{
    [SerializeField] private Basket _receptionBasket;
    [SerializeField] private float _timeTakeItem;
    private float _currentTime = 0;

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            _currentTime += Time.deltaTime;

            if (_receptionBasket.CurrentCountItems > 0)
            {
                if (_currentTime >= _timeTakeItem)
                {
                    _currentTime = 0;
                    Debug.Log("Игрок найден");
                    player.TakeItem(_receptionBasket.RevoveItem());
                    _receptionBasket.SortContainer();
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            _currentTime = 0;
        }
    }
}
