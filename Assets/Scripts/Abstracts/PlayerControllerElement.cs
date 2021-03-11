using System;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

namespace Abstracts
{
    /// <summary>
    /// An abstract class controlling the player <br/>
    /// and the player's ammo
    /// </summary>
    public abstract class PlayerControllerElement : MonoBehaviour
    {
        [SerializeField] protected PlayerViewElement _playerView;
        [SerializeField] protected ProjectileViewElement _bullet;
        [SerializeField] protected int _bulletCount;

        private List<ProjectileViewElement> _ammo;

        private void Start()
        {
            InstantiateAmmoPool();
        }

        /// <summary>
        /// Instantiate the ammo pool
        /// </summary>
        private void InstantiateAmmoPool()
        {
            _ammo = new List<ProjectileViewElement>();
            // Create a list of bullets - an object pool, and inject thyself to all the bullets
            for (int i = 0; i < _bulletCount; i++)
            {
                var projectile = Instantiate(_bullet);
                projectile.gameObject.SetActive(false);
                _ammo.Add(projectile);
                projectile.Inject(this);
            }
            _playerView.Inject(this);
        }

        /// <summary>
        /// Used to retrieve ammo from the object pool
        /// </summary>
        /// <returns> ProjectileViewElement that is available according to the ammo capacity </returns>
        protected ProjectileViewElement GetPooledAmmo()
        {
            for (int i = 0; i < _bulletCount; i++)
            {
                if (!_ammo[i].gameObject.activeInHierarchy)
                {
                    return _ammo[i];
                }
            }

            return null;
        }
        
        /// <summary>
        /// Invoked when the shoot button is pressed
        /// </summary>
        /// <param name="player"> The player receiving the shoot button press </param>
        public abstract void ShootButtonPressed(PlayerViewElement player);

        /// <summary>
        /// Invoked when a projectile hits the ceiling
        /// </summary>
        /// <param name="projectile"> The projectile hitting the ceiling </param>
        public abstract void ProjectileHitCeiling(ProjectileViewElement projectile);

        /// <summary>
        /// Invoked when a projectile hits a ball
        /// </summary>
        /// <param name="projectile"> The projectile that hit a ball </param>
        public abstract void ProjectileHitBall(ProjectileViewElement projectile);

        /// <summary>
        /// Invoked when a player dies
        /// </summary>
        /// <param name="player">The player who died</param>
        public abstract void PlayerDied(PlayerViewElement player);
    }
}