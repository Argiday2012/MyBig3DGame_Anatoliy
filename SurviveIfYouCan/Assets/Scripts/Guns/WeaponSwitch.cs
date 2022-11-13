using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    [SerializeField] private int _weaponSwitch = 0;

    private void Start()
    {
        WeaponSelect();
    }

    private void Update()
    {
        int _currentWeapon = _weaponSwitch;

        if(Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if(_weaponSwitch >= transform.childCount - 1 )
            {
                _weaponSwitch = 0;
            }
            else
            {
                _weaponSwitch++;
            }
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (_weaponSwitch <= 0)
            {
                _weaponSwitch = transform.childCount - 1;
            }
            else
                _weaponSwitch--;
        }

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            _weaponSwitch = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2)
        {
            _weaponSwitch = 1;
        }

        if (_currentWeapon != _weaponSwitch)
        {
            WeaponSelect();
        }
    }

    void WeaponSelect()
    {
        int i = 0;
        foreach(Transform weapon in transform)
        {
            if(i == _weaponSwitch)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            i++;

        }
    }
}
