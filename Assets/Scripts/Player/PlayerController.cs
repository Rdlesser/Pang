using Abstracts;

namespace Player
{
    public class PlayerController : PlayerControllerElement
    {
        
        private bool _canShoot = true;
        
        public override void ShootButtonPressed(PlayerViewElement player)
        {
            if (_canShoot)
            {
                var projectile = GetPooledAmmo();
                if (projectile != null)
                {
                    player.Shoot(projectile);
                }
            }
        }

        public override void ProjectileHitCeiling(ProjectileViewElement projectile)
        {
            projectile.gameObject.SetActive(false);
        }

        public override void ProjectileHitBall(ProjectileViewElement projectile)
        {
            projectile.gameObject.SetActive(false);
        }

        public override void PlayerDied(PlayerViewElement player)
        {
            _canShoot = false;
        }

        public override void PreventPlayerMovement()
        {
            _playerView.PreventMovement();
        }
    }
}