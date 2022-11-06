using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private float _damage = 10f;
    [SerializeField] private float _fireRate = 1f;
    [SerializeField] private float _range = 10f;

    public Camera Cam;


    void Shoot()
    {
        RaycastHit hit;

        if (Physics.Raycast(Cam.transform.position, Cam.transform.forward, out hit, _range))
        {
            Debug.Log("Hit");
        }
    }

}
