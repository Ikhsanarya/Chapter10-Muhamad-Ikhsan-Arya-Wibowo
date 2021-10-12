using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CircleController : MonoBehaviour
{
    public float maxSpeed = 10.0f;
    public float initialForce = 5.0f;

    private Rigidbody2D _rigidbody2D;
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Move()
    {
        float random = Random.Range(-initialForce, initialForce);

        _rigidbody2D.AddForce(
            Random.Range(-1, 1) < 0
                ? Vector2.ClampMagnitude(new Vector2(-initialForce, random), maxSpeed)
                : Vector2.ClampMagnitude(new Vector2(initialForce, random), maxSpeed), ForceMode2D.Impulse);
    }

    public void Move(float x, float y)
    {
        _rigidbody2D.velocity = Vector2.ClampMagnitude(new Vector2(x * initialForce, y * initialForce), maxSpeed);
    }
}
