using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Ball : MonoBehaviour
{

    [SerializeField] private bool _moveRight;
    [SerializeField] private GameObject _originalBall;
    [SerializeField] private AudioClip[] _popSounds;
    [SerializeField] private float _forceX = 2.5f;
    [SerializeField] private float _forceY;

    private Rigidbody2D _rigidbody;
    private GameObject _leftBall;
    private GameObject _rightBall;
    private Ball _leftBallScript;
    private Ball _rightBallScript;
    
    

    // Start is called before the first frame update
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        SetBallSpeed();
    }

    private void SetBallSpeed()
    {
        _forceX = 2.5f;
        
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.CompareTag("Ground"))
        {
            _rigidbody.velocity = new Vector2(0, _forceY);
        }
    }

}
