using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerView : MonoBehaviour
{
    [SerializeField] private GameObject _projectile;
    [SerializeField] private AudioClip _shootSound;
    [SerializeField] private AudioClip _deathSound;
    [SerializeField] private float _playerSpeed = 8f;
    [SerializeField] private float _maxVelocity = 4f;

    private Rigidbody2D _rigidbody;

    private bool _canWalk = true;
    private bool _canShoot = true;
    
    // Start is called before the first frame update
    public void Start()
    {
        Init();
    }

    private void Update()
    {
        Shoot();
    }

    private void FixedUpdate()
    {
        Walk();
    }


    private void Init()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Walk()
    {
        var force = 0f;
        var velocity = Mathf.Abs(_rigidbody.velocity.x);

        float horizontal = Input.GetAxis("Horizontal");

        if (_canWalk)
        {
            if (horizontal > 0)
            {
                // moving right
                if (velocity < _maxVelocity)
                {
                    force = _playerSpeed;
                }
            }
            else if (horizontal < 0)
                // moving left
            {
                if (velocity < _maxVelocity)
                {
                    force = -_playerSpeed;
                }
            }
            
        }
        _rigidbody.AddForce(new Vector2(force, 0));
    }

    public void Shoot()
    {
        if (Input.GetButton("Fire1"))
        {
            if (_canShoot)
            {
                _canShoot = false;
                StartCoroutine(ShootCoroutine());
            }
        }
    }
    
    public IEnumerator ShootCoroutine()
    {
        _canWalk = false;

        var playerTransform = transform;
        var playerPosition = playerTransform.position;
        
        Vector3 shootPosition = playerPosition;
        shootPosition.y += 0.5f * playerTransform.lossyScale.y;

        Instantiate(_projectile, shootPosition, Quaternion.identity);
        AudioSource.PlayClipAtPoint(_shootSound, playerPosition);
        
        yield return new WaitForSeconds(0.2f);

        _canWalk = true;

        yield return new WaitForSeconds(0.3f);
        _canShoot = true;
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.CompareTag("Ball"))
        {
            Death();
        }
    }

    public void Death()
    {
        AudioSource.PlayClipAtPoint(_deathSound, transform.position);
    }

}
