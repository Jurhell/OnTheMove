using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MomentumBehavior : MonoBehaviour
{
    [SerializeField]
    private float _speed = 1;

    [SerializeField]
    private float _maxSpeed = 30;

    [SerializeField]
    private GameOver _gameOverBehavior;

    private float _acceleration = 0.16f;

    private float _deceleration = 0.32f;

    private float _graceTimer;

    public float Speed
    {
        get
        {
            return _speed;
        }
    } 

    public float MaxSpeed
    {
        get
        {
            return _maxSpeed;
        }
    }

    void FixedUpdate()
    {
        _graceTimer += Time.deltaTime;

        if (Input.GetButton("Vertical"))
        {
            _speed += _acceleration;

            if (_speed > _maxSpeed)
                _speed = _maxSpeed;

            return;
        }

        _speed -= _deceleration;

        if (_speed < 0.0f)
            _speed = 0;

        if (_graceTimer >= 3.0f)
        {
            Debug.Log("Grace is over");

            if (_speed <= 0.0)
            {
                _gameOverBehavior.Lost = true;
                _gameOverBehavior.GameOverCall();
            }
        }
    }

}
