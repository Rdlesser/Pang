using Interfaces;
using UnityEngine;

namespace Abstracts
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class PlayerViewElement : MonoBehaviour, 
                                              IInjectifiable<PlayerControllerElement>,
                                              IInjectifiable<GameManagerElement>
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
        
        /// <summary>
        /// Method called by the controller to shoot a projectile
        /// </summary>
        /// <param name="projectile"> The projectile to shoot </param>
        public abstract void Shoot(ProjectileViewElement projectile);

        /// <summary>
        /// Method called when the player needs to react to death
        /// </summary>
        public abstract void PreventMovement();
        
        public abstract void Inject(PlayerControllerElement injection);

        public abstract void Inject(GameManagerElement gameManager);
    }
    
    
}