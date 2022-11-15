using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
   // [SerializeField] private float _damage = 10f;
    [SerializeField] private float _fireRate = 3f;
    [SerializeField] private float _range = 10f;
    [SerializeField] private float _force = 125f;
    [SerializeField] private int _currentAmmo;
    [SerializeField] private int _allAmmo;

    [SerializeField] private Text _countAmmo;

    public Camera Cam;
    private float _nextFire = 0f;


    private void Update()
    {
        if(Input.GetButton("Fire1") && Time.time > _nextFire && _currentAmmo > 0)
        {
            _nextFire = Time.time + 1f / _fireRate;
            Shoot();
            _currentAmmo -= 1;
            
        }

        _countAmmo.text = _currentAmmo + "/" + _allAmmo;
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
