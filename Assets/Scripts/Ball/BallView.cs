using System;
using Abstracts;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallView : BallViewElement
{

#region Events

    private Action<BallViewElement> _onBallHitGroundEvent;
    private Action<BallViewElement, MoveDirection> _onBallHitWallEvent;
    private Action<BallViewElement> _onBallHitProjectileEvent;
    private Action<BallViewElement, BallViewElement> _onBallSplitEvent;
    

#endregion
    
    private GameObject _leftBall;
    private GameObject _rightBall;
    private BallViewElement _leftBallViewScript;
    private BallViewElement _rightBallViewScript;
    

    

    protected override void OnHitGround()
    {
        _onBallHitGroundEvent?.Invoke(this);
    }

    public override void Bounce()
    {
        _rigidbody.velocity = new Vector2(0, _bounceForce);
    }

    protected override void OnHitWall()
    {
        _onBallHitWallEvent?.Invoke(this, _moveDirection);
    }

    protected override void OnHitProjectile()
    {
        _onBallHitProjectileEvent?.Invoke(this);
    }

    public override void SplitBall()
    {
        if (_childBall != null)
        {
            var ballPosition = transform.position;
            _leftBall = Instantiate(_childBall, ballPosition, Quaternion.identity);
            _leftBallViewScript = _leftBall.GetComponent<BallViewElement>();
            
            _rightBall = Instantiate(_childBall, ballPosition, Quaternion.identity);
            _rightBallViewScript = _rightBall.GetComponent<BallViewElement>();

            _onBallSplitEvent?.Invoke(_leftBallViewScript, _rightBallViewScript);
            
        }
        
        AudioSource.PlayClipAtPoint(_popSounds[Random.Range(0, _popSounds.Length)], transform.position);
        Destroy(gameObject);
    }

    public override void Inject(BallControllerElement injection)
    {
        _onBallHitGroundEvent += injection.OnHitGround;
        _onBallHitWallEvent += injection.OnHitWall;
        _onBallHitProjectileEvent += injection.OnHitProjectile;
        _onBallSplitEvent += injection.OnBallSplit;
    }
}
