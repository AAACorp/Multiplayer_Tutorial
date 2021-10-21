using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _lookingSensetivity = 5f;

    private PlayerMotor motor;

    void Start()
    {
        motor = GetComponent<PlayerMotor>();
    }

    void Update()
    {
        float _xMove = Input.GetAxisRaw("Horizontal");
        float _zMove = Input.GetAxisRaw("Vertical");

        Vector3 _moveHorizontal = transform.right * _xMove;
        Vector3 _moveVertical = transform.forward * _zMove;

        Vector3 _velocityVector = (_moveHorizontal + _moveVertical).normalized * _speed;

        motor.Move(_velocityVector);

        float _yRotation = Input.GetAxisRaw("Mouse X");
        Vector3 _rotation = new Vector3(0f, _yRotation, 0f) * _lookingSensetivity;

        motor.Rotate(_rotation);

        float _xRotation = Input.GetAxisRaw("Mouse Y");
        Vector3 _cameraRotation = new Vector3(_xRotation, 0f, 0f) * _lookingSensetivity;

        motor.RotateCamera(_cameraRotation);
    }

}
