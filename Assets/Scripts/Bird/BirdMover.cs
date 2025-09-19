using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BirdMover : MonoBehaviour
{
    [SerializeField] private float _tapForce;
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _maxRotationZ;
    [SerializeField] private float _minRotationZ;
    [SerializeField] private UserInput _userInput;

    private Vector3 _startPosition;
    private Vector2 _startVelocitry;
    private Rigidbody2D _rigidbody;
    private Quaternion _startRotation;
    private Quaternion _maxRotation;
    private Quaternion _minRotation;

    private void Start()
    {
        _startPosition = transform.position;
        _startRotation = transform.rotation;
        _rigidbody = GetComponent<Rigidbody2D>();

        float startJumpForce = _tapForce / 2;
        _startVelocitry = new Vector2(_speed, startJumpForce);
        _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
        _minRotation = Quaternion.Euler(0, 0, _minRotationZ);
    }

    private void OnEnable()
    {
        _userInput.JumpKeyPressed += Move;
    }

    private void OnDisable()
    {
        _userInput.JumpKeyPressed -= Move;
    }

    private void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
    }

    public void Initialize(UserInput userInput)
    {
        _userInput = userInput;
    }

    public void Reset()
    {
        _rigidbody.velocity = _startVelocitry;
        //_rigidbody.velocity = Vector2.zero;
        transform.position = _startPosition;
        transform.rotation = _startRotation;
    }

    private void Move()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody.velocity = new Vector2(_speed, _tapForce);
            transform.rotation = _maxRotation;
        }
    }
}
