using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CircleController : MonoBehaviour
{
    public float maxSpeed = 5.0f;
    public float initialForce = 3.0f;

    private Rigidbody2D _rigidbody2D;
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        
        Move();
    }

    private void Move()
    {
        float random = Random.Range(-initialForce, initialForce);

        if (Random.Range(-1, 1) < 0)
        {
            Debug.Log("left");
            _rigidbody2D.AddForce(Vector2.ClampMagnitude(new Vector2(-initialForce, random), maxSpeed), ForceMode2D.Impulse);
        }
        else
        {
            _rigidbody2D.AddForce(Vector2.ClampMagnitude(new Vector2(initialForce, random), maxSpeed), ForceMode2D.Impulse);
        }
    }
}
