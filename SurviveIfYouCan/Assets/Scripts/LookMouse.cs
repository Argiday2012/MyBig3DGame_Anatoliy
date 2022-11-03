using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookMouse : MonoBehaviour
{
    private float _mouseX;
    private float _mouseY;

    [Header("Mouse Intensity")]
    public float IntensityMouse = 200f;

    public Transform Player;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        _mouseX = Input.GetAxis("Mouse X") * IntensityMouse * Time.deltaTime;
        _mouseY = Input.GetAxis("Mouse Y") * IntensityMouse * Time.deltaTime;

        Player.Rotate(_mouseX * new Vector3(0, 1, 0));

        transform.Rotate(-_mouseY * new Vector3(1, 0, 0));
    }
}
