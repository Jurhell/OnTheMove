using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private Transform _target;

    [SerializeField]
    private float _smoothTime = 0.5f;
    private Vector3 _offset;

    private void Start()
    {
        _offset = _target.position - transform.position;
    }

    private void FixedUpdate()
    {
        Vector3 velocity = Vector3.zero;
        transform.position = Vector3.SmoothDamp(transform.position, _target.position - _offset, ref velocity, _smoothTime);
        //transform.LookAt(_target);
    }
}
