using System.Collections.Generic;
using Interfaces;
using UnityEngine;

namespace Abstracts
{
    /// <summary>
    /// An abstract class of a ball controller
    /// </summary>
    public abstract class BallControllerElement : MonoBehaviour, IInjectifiable<GameManagerElement>
    {
        // A List of all the level balls
        [SerializeField] protected List<BallViewElement> _levelBalls;
        
        private void Start()
        {
            foreach (var ball in _levelBalls)
            {
                ball.Inject(this);
            }
        }
        
        /// <summary>
        /// Method to be called when a ball hits the ground
        /// </summary>
        /// <param name="ball"> The ball that hit the ground </param>
        public abstract void OnHitGround(BallViewElement ball);

        /// <summary>
        /// Method to be called when a ball hits a wall
        /// </summary>
        /// <param name="ball"> The ball that hit the wall </param>
        /// <param name="direction"> The direction the ball was moving on the X axis </param>
        public abstract void OnHitWall(BallViewElement ball, MoveDirection direction);

        /// <summary>
        /// Method to be called when a ball hits a projectile
        /// </summary>
        /// <param name="ball"> The ball that hit the projectile </param>
        public abstract void OnHitProjectile(BallViewElement ball);

        /// <summary>
        /// Method to be called when a ball splits into 2
        /// </summary>
        /// <param name="leftBall"></param>
        /// <param name="rightBall"></param>
        public abstract void OnBallSplit(BallViewElement parentBall, BallViewElement leftBall, BallViewElement rightBall);

        public abstract void Inject(GameManagerElement injection);
    }
}