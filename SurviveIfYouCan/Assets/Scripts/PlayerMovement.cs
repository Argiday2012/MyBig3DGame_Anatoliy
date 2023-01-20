using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rb;

    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _runSpeed = 30f;
    [SerializeField] private float JumpForce;
    public Joystick _joystick;
    private bool _inAir;

    public static float Horizontal;
    public static float Vertical;


    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void Jump()
    {
        if (_inAir != true)
        {
            _rb.AddForce(transform.up * JumpForce, ForceMode.Impulse);
        }
    }

    private void Update()
    {

        //Horizontal = Input.GetAxis("Horizontal");
        Horizontal = _joystick.Horizontal;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(0, 0, Vertical * _runSpeed * Time.deltaTime);
        }
        else
        {
            //Vertical = Input.GetAxis("Vertical");
            Vertical = _joystick.Vertical;
        }

        //if(/*Input.GetButtonDown("Jump") && */  _inAir != true)
        //{
        //    _inAir = true;
        //    Jump();
        //}
    }

    private void FixedUpdate()
    {
        transform.Translate(Horizontal * _speed * Time.fixedDeltaTime, 0, 0);
        transform.Translate(0, 0, Vertical * _speed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            _inAir = false;
        }
    }
}
