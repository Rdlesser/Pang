using Interfaces;
using UnityEngine;

namespace Abstracts
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class ProjectileViewElement : MonoBehaviour, IInjectifiable<PlayerControllerElement>
    {
        
        [SerializeField] protected float _speed = 5f;
        
        protected Rigidbody2D _rigidbody2D;
    
        // Start is called before the first frame update
        public void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }
        
        public void FixedUpdate()
        {
            _rigidbody2D.velocity = new Vector2(0, _speed);
        }
        
        private void OnTriggerEnter2D(Collider2D target)
        {
            if (target.CompareTag("Ceiling"))
            {
                OnHitCeiling();
                return;
            }

            if (target.CompareTag("Ball"))
            {
                OnHitBall();
            }
        }

        protected abstract void OnHitCeiling();

        protected abstract void OnHitBall();

        public abstract void Inject(PlayerControllerElement injection);

    }
}