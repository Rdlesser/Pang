using System.Collections;
using Abstracts;
using UnityEngine;

namespace Player
{
    public class PlayerView : PlayerViewElement
    {

        private bool _canWalk = true;
        private bool _canShoot = true;
    
        private void Update()
        {
            Shoot();
        }

        private void FixedUpdate()
        {
            Walk();
        }



        public override void Walk()
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

        public override void Shoot()
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
}
