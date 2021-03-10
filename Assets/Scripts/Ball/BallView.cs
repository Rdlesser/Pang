using System;
using UnityEngine;
using Random = UnityEngine.Random;

public enum MoveDirection
{
    Right,
    Left
}


public class BallView : MonoBehaviour
{

    [SerializeField] private MoveDirection _moveDirection = MoveDirection.Right;
    [SerializeField] private GameObject _childBall;
    [SerializeField] private AudioClip[] _popSounds;
    [SerializeField] private float _forceX = 2.5f;
    [SerializeField] private float _forceY;
    
    private Rigidbody2D _rigidbody;
    private GameObject _leftBall;
    private GameObject _rightBall;
    private BallView _leftBallViewScript;
    private BallView _rightBallViewScript;
    
    

    // Start is called before the first frame update
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        MoveBallHorizontally();
    }
    
    public void SetMoveDirection(MoveDirection newDirection)
    {
        _moveDirection = newDirection;
    }

    private void MoveBallHorizontally()
    {
        float direction = _moveDirection == MoveDirection.Right ? 1f : -1f;
        var ballTransform = transform;
        Vector3 newPosition = ballTransform.position;
        newPosition.x += _forceX * Time.deltaTime * direction;
        ballTransform.position = newPosition;
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.CompareTag("Ground"))
        {
            _rigidbody.velocity = new Vector2(0, _forceY);
        }

        if (target.CompareTag("Right Wall"))
        {
            _moveDirection = MoveDirection.Left;
        }
        else if (target.CompareTag("Left Wall"))
        {
            _moveDirection = MoveDirection.Right; 
        }

        if (target.CompareTag("Projectile"))
        {
            InstantiateBalls();
        }
    }
    
    private void InstantiateBalls()
    {
        Debug.Log("Instantiating");
        if (_childBall != null)
        {
            var ballPosition = transform.position;
            _leftBall = Instantiate(_childBall, ballPosition, Quaternion.identity);
            _leftBallViewScript = _leftBall.GetComponent<BallView>();
            _leftBallViewScript.SetMoveDirection(MoveDirection.Left);
            _rightBall = Instantiate(_childBall, ballPosition, Quaternion.identity);
            _rightBallViewScript = _rightBall.GetComponent<BallView>();
            _rightBallViewScript.SetMoveDirection(MoveDirection.Right);

            _leftBall.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 2.5f);
            _rightBall.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 2.5f);
            
        }
        
        AudioSource.PlayClipAtPoint(_popSounds[Random.Range(0, _popSounds.Length)], transform.position);
        Destroy(gameObject);
    }

}
