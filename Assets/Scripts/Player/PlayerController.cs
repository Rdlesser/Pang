using Abstracts;

namespace Player
{
    public class PlayerController : PlayerControllerElement
    {
        
        public override void ShootButtonPressed(PlayerViewElement player)
        {
            var projectile = GetPooledAmmo();
            if (projectile != null)
            {
                player.Shoot(projectile);
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
    }
}