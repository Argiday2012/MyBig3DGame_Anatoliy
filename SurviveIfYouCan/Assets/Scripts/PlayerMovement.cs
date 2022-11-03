using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rb;

    [SerializeField] private float _speed = 10f;

    public static float Horizontal;
    public static float Vertical;


    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        transform.Translate(Horizontal * _speed * Time.fixedDeltaTime, 0, 0);
        transform.Translate(0, 0, Vertical * _speed * Time.fixedDeltaTime);
    }
}
