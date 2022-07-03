using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : MonoBehaviour
{
    [SerializeField] private Transform _startPosition;
    [SerializeField] private float _speed;

    private List<Transform> _patrulPoints;
    private int _indexPoint;
    private Rigidbody _rb;
    private Vector3 _direction;

    public Transform StartPosition => _startPosition;
  
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _indexPoint = 0;
    }

    private void Update()
    {
        Patruling();
    }

    public void InitPatrulPoints(List<Transform> patrulPoints)
    {
        _patrulPoints = patrulPoints;
    }

    private void Patruling()
    {
        transform.position = Vector3.MoveTowards(transform.position, _patrulPoints[_indexPoint].position, _speed * Time.deltaTime);
        _direction = _patrulPoints[_indexPoint].position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(_direction * Time.deltaTime);
        transform.rotation = rotation;

        if (transform.position == _patrulPoints[_indexPoint].position)
        {
            if (_indexPoint < _patrulPoints.Count - 1)
            {
                _indexPoint++;
            }
            else
            {
                _indexPoint = 0;
            }
        }
    }
}
