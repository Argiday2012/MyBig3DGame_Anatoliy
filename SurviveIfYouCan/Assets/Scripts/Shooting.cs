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
    [SerializeField] private int _importantAmmo;
    [SerializeField] private int _allAmmo;

    [SerializeField] private GameObject _forMuzzle;
    [SerializeField] private AudioClip shotSFX;
    [SerializeField] private AudioSource _audioBySource; 

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

        if(Input.GetKey(KeyCode.R) && _allAmmo > 0)
        {
            Reload();
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

    void Reload()
    {
        int _reason = _importantAmmo - _currentAmmo;
        if(_allAmmo >= _reason)
        {
            _allAmmo = _allAmmo - _reason;
            _currentAmmo = _importantAmmo;
        }
        else
        {
            _currentAmmo = _currentAmmo + _allAmmo;
            _allAmmo = 0;
        }
    }

}
