using Interfaces;
using UnityEngine;

namespace Abstracts
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class PlayerViewElement : MonoBehaviour, IInjectifiable<PlayerControllerElement>
    {
        [SerializeField] protected GameObject _projectile;
        [SerializeField] protected AudioClip _shootSound;
        [SerializeField] protected AudioClip _deathSound;
        [SerializeField] protected float _playerSpeed = 8f;
        [SerializeField] protected float _maxVelocity = 4f;

        protected Rigidbody2D _rigidbody;
        
        // Start is called before the first frame update
        public void Start()
        {
            Init();
        }

        private void Init()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        public abstract void Walk();

        public abstract void Shoot(ProjectileViewElement projectile);

        public abstract void ProjectileHitCeiling(ProjectileViewElement projectile);

        public abstract void ProjectileHitBall(ProjectileViewElement projectile);
        public abstract void Inject(PlayerControllerElement injection);
    }
    
    
}