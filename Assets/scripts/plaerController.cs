using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plaerController : MonoBehaviour
{
public float Gravity = 9.8f;
    public float JampForce;
    public float Speed;

    private float _fallVelocity = 1;
    private Vector3 _moveVector;

    private CharacterController _CharacterController;
    
    // Start is called before the first frame update
    void Start()
    {
        _CharacterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    private void Update()
    {

        _moveVector = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            _moveVector += transform.forward;
        }
        //if (Input.GetKey(KeyCode.S))
        {
            _moveVector -= transform.forward;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _moveVector += transform.right;
        }
        if (Input.GetKey(KeyCode.A))
        {
            _moveVector -= transform.right;
        }
        if (Input.GetKeyDown(KeyCode.Space) && _CharacterController.isGrounded)
        {
          _fallVelocity = -JampForce;
        }
        
    }
    void FixedUpdate()
    {
        _CharacterController.Move(_moveVector * Speed * Time.fixedDeltaTime);

        _fallVelocity += Gravity * Time.fixedDeltaTime;
        _CharacterController.Move(Vector3.down * _fallVelocity * Time.fixedDeltaTime);

        if (_CharacterController.isGrounded)
        {
            _fallVelocity = 0;
        }
    }

}