using Interfaces;
using UnityEngine;

namespace Abstracts
{
    /// <summary>
    /// Enumeration of the direction the ball is moving on the X axis
    /// </summary>
    public enum MoveDirection
    {
        Right,
        Left
    }
    
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class BallViewElement : MonoBehaviour, IInjectifiable<BallControllerElement>
    {

    #region Serialized fields

        [SerializeField][Tooltip("The direction the ball is moving")] 
        protected MoveDirection _moveDirection = MoveDirection.Right;
        
        [SerializeField][Tooltip("The balls that are to be split away from this ball when it is hit by a projectile")]
        protected GameObject _childBall;
        
        [SerializeField][Tooltip("An array of sounds to be used as a random pop sound is chosen when the ball is popped")] 
        protected AudioClip[] _popSounds;
        
        [SerializeField][Tooltip("Movement speed on the X axis")] 
        protected float _forceX = 2.5f;
        
        [SerializeField][Tooltip("Force of bounce")] 
        protected float _bounceForce;

    #endregion

    #region protected fields

        protected Rigidbody2D _rigidbody;

    #endregion

        public Rigidbody2D Rigidbody => _rigidbody;
        
        
        // Start is called before the first frame update
        void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }
        
        private void Update()
        {
            MoveBallHorizontally();
        }

        /// <summary>
        /// Set the direction of the ball on the X axis
        /// </summary>
        /// <param name="newDirection"> The new direction </param>
        public void SetMoveDirection(MoveDirection newDirection)
        {
            _moveDirection = newDirection;
        }

        /// <summary>
        /// Controls the movement of the ball on the horizontal axis
        /// </summary>
        private void MoveBallHorizontally()
        {
            float direction = _moveDirection == MoveDirection.Right ? 1f : -1f;
            var ballTransform = transform;
            Vector3 newPosition = ballTransform.position;
            newPosition.x += _forceX * Time.deltaTime * direction;
            ballTransform.position = newPosition;
        }
        
        protected void OnTriggerEnter2D(Collider2D target)
        {
            if (target.CompareTag("Ground"))
            {
                OnHitGround();
            }

            if (target.CompareTag("Right Wall") || target.CompareTag("Left Wall"))
            {
                OnHitWall();
            }

            if (target.CompareTag("Projectile"))
            {
                OnHitProjectile();
            }
        }

        /// <summary>
        /// Called when the ball hits the ground
        /// </summary>
        protected abstract void OnHitGround();

        /// <summary>
        /// Called when the ball hits a wall
        /// </summary>
        protected abstract void OnHitWall();

        /// <summary>
        /// Called when the ball hits a projectile
        /// </summary>
        protected abstract void OnHitProjectile();

        /// <summary>
        /// Called by the controller to make the ball bounce up off the ground
        /// </summary>
        public abstract void Bounce();

        /// <summary>
        /// Called by the controller to make the ball split into 2
        /// </summary>
        public abstract void SplitBall();

        public abstract void Inject(BallControllerElement injection);
    }
}