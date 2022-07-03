using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Bot _botTemplate;
    [SerializeField] private Item _itemTemplate;
    [SerializeField] private float _countsBots;
    [SerializeField] private List<Transform> _patrulPoints;
    [SerializeField] private float _timeSpawn;

    private float _timeLastSpawn = 0;

    private void Update()
    {
        _timeLastSpawn += Time.deltaTime;

        if (_countsBots < 0)
        {
            return;
        }

        if (_timeLastSpawn >= _timeSpawn)
        {
            Bot newBot = Instantiate(_botTemplate, transform.position, Quaternion.identity);
            Item newItem = Instantiate(_itemTemplate, transform.position, Quaternion.identity);
            newBot.InitPatrulPoints(_patrulPoints);
            newItem.SetParrent(newBot.gameObject);
            _countsBots--;
            _timeLastSpawn = 0;
        }
       
    }
}
