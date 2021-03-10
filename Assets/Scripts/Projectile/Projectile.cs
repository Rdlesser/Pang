using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    
    private Rigidbody2D _rigidbody2D;
    
    // Start is called before the first frame update
    void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _rigidbody2D.velocity = new Vector2(0, _speed);
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.CompareTag("Ceiling"))
        {
            Destroy(gameObject);
            return;
        }

        if (target.GetComponent<BallView>() != null)
        {
            Destroy(gameObject);
        }
    }
}
