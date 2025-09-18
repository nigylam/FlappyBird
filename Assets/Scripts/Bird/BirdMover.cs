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
    private Rigidbody2D _rigidbody;
    private Quaternion _startRotation;
    private Quaternion _maxRotation;
    private Quaternion _minRotation;

    private bool _isFreezed = false;

    private void Start()
    {
        _startPosition = transform.position;
        _startRotation = transform.rotation;
        _rigidbody = GetComponent<Rigidbody2D>();

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

    private void Move()
    {
        if (_isFreezed)
            return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody.velocity = new Vector2(_speed, _tapForce);
            transform.rotation = _maxRotation;
        }
    }

    private void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
    }

    public void Reset()
    {
        _rigidbody.velocity = Vector2.zero;
        transform.position = _startPosition;
        transform.rotation = _startRotation;
        _isFreezed = false;
    }

    public void Freeze()
    {
        _isFreezed = true;
    }
}
