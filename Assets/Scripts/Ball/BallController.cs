using System;
using Abstracts;
using UnityEngine;

namespace Ball
{
    public class BallController : BallControllerElement
    {

    #region Events

        private Action _onEmptyBallList;

    #endregion

        public override void OnHitGround(BallViewElement ball)
        {
            ball.Bounce();
        }

        public override void OnHitWall(BallViewElement ball, MoveDirection direction)
        {
            ball.SetMoveDirection(direction == MoveDirection.Left ? MoveDirection.Right : MoveDirection.Left);
        }

        public override void OnHitProjectile(BallViewElement ball)
        {
            ball.SplitBall();
        }

        public override void OnBallSplit(BallViewElement parentBall, BallViewElement leftBall, BallViewElement rightBall)
        {

            _levelBalls.Remove(parentBall);
            
            if (leftBall == null)
            {
                if (_levelBalls.Count == 0)
                {
                    _onEmptyBallList?.Invoke();
                }
                return;
            }
            _levelBalls.Add(leftBall);
            _levelBalls.Add(rightBall);
            
            leftBall.Rigidbody.velocity = new Vector2(0, 2.5f);
            rightBall.Rigidbody.velocity = new Vector2(0, 2.5f);
            
            leftBall.SetMoveDirection(MoveDirection.Left);
            rightBall.SetMoveDirection(MoveDirection.Right);
            
            leftBall.Inject(this);
            rightBall.Inject(this);
            
        }

        public override void Inject(GameManagerElement injection)
        {
            _onEmptyBallList += injection.OnPoppedAllBalls;
        }
    }
}