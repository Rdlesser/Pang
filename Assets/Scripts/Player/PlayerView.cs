using System;
using System.Collections;
using Abstracts;
using UnityEngine;

namespace Player
{
    public class PlayerView : PlayerViewElement
    {

    #region Events
        
        private Action<PlayerViewElement> _onShootButtonPressed;

    #endregion

        private bool _canWalk = true;

        private void Update()
        {
            if (Input.GetButton("Fire1"))
            {
                ShootButtonPressed();
            }
            // Shoot();
        }

        private void ShootButtonPressed()
        {
            _onShootButtonPressed?.Invoke(this);
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

        public override void Shoot(ProjectileViewElement projectile)
        {
            var playerTransform = transform;
            var playerPosition = playerTransform.position;
        
            Vector3 shootPosition = playerPosition;
            shootPosition.y += 0.5f * playerTransform.lossyScale.y;
            projectile.transform.position = shootPosition;
            projectile.gameObject.SetActive(true);
        }

        public override void ProjectileHitCeiling(ProjectileViewElement projectile)
        {
            projectile.gameObject.SetActive(false);
        }

        public override void ProjectileHitBall(ProjectileViewElement projectile)
        {
            projectile.gameObject.SetActive(false);
        }

        public override void Inject(PlayerControllerElement injection)
        {
            _onShootButtonPressed += injection.ShootButtonPressed;
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
