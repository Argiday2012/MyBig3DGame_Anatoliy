using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private float _damage = 10f;
    [SerializeField] private float _fireRate = 3f;
    [SerializeField] private float _range = 10f;
    [SerializeField] private float _force = 125f;

    public Camera Cam;
    private float _nextFire = 0f;


    private void Update()
    {
        if(Input.GetButton("Fire1") && Time.time > _nextFire)
        {
            _nextFire = Time.time + 1f / _fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;

        if (Physics.Raycast(Cam.transform.position, Cam.transform.forward, out hit, _range))
        {
            Debug.Log("Hit");

            if(hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * _force);
            }
        }
    }

}
