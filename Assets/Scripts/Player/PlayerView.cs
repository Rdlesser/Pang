using System;
using System.Collections;
using Abstracts;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Animator))]
    public class PlayerView : PlayerViewElement
    {

    #region Events
        
        private Action<PlayerViewElement> _onShootButtonPressed;
        private Action<PlayerViewElement> _onPlayerHitByBall;

    #endregion

    #region private fields

        private Animator _animator;
        private static readonly int DieAnimatorTrigger = Animator.StringToHash("Die");

    #endregion

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            if (Input.GetButton("Fire1"))
            {
                ShootButtonPressed();
            }
        }

        private void ShootButtonPressed()
        {
            _onShootButtonPressed?.Invoke(this);
        }

        private void FixedUpdate()
        {
            Walk();
        }


        private void Walk()
        {
            var force = 0f;
            var velocity = Mathf.Abs(_rigidbody.velocity.x);

            float horizontal = Input.GetAxis("Horizontal");

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
            AudioSource.PlayClipAtPoint(_shootSound, transform.position);
        }

        public override void Die()
        {
            _animator.SetTrigger(DieAnimatorTrigger);
        }

        public override void Inject(PlayerControllerElement injection)
        {
            _onShootButtonPressed += injection.ShootButtonPressed;
        }

        public override void Inject(GameManagerElement injection)
        {
            _onPlayerHitByBall += injection.OnPlayerHitByBall;
        }

        private void OnTriggerEnter2D(Collider2D target)
        {
            if (target.CompareTag("Ball"))
            {
                OnPlayerHitByBall();
            }
        }

        public void OnPlayerHitByBall()
        {
            AudioSource.PlayClipAtPoint(_deathSound, transform.position);
            _onPlayerHitByBall?.Invoke(this);
        }

    }
}
