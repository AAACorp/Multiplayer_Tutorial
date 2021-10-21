using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour
{
    [SerializeField] private Camera _cam;

    private Rigidbody _rb;

    private Vector3 _velocityVector = Vector3.zero;
    private Vector3 _rotation = Vector3.zero;
    private Vector3 _rotationCamera = Vector3.zero;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        PerformMove();
        PerformRotation();
    }

    private void PerformRotation()
    {
        _rb.MoveRotation(_rb.rotation * Quaternion.Euler(_rotation));

        if(_cam)
        {
            _cam.transform.Rotate(-_rotationCamera);
        }
    }

    public void Rotate(Vector3 _rotate)
    {
        _rotation = _rotate;
    }
    public void RotateCamera(Vector3 _rotate)
    {
        _rotationCamera = _rotate;
    }
    public void Move(Vector3 _vel)
    {
        _velocityVector = _vel;
    }

    private void PerformMove()
    {
        if(_velocityVector != Vector3.zero)
        {
            _rb.MovePosition(_rb.position + _velocityVector * Time.fixedDeltaTime);
        }
    }
}
