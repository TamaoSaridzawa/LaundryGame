using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalkerCamera : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private Vector3 _currentPosition;

    private void Start()
    {
        _currentPosition = transform.position - _target.position ;
        Cursor.visible = false;
    }

    void LateUpdate()
    {
        transform.position = _target.transform.position + _currentPosition;
      
    }
}
