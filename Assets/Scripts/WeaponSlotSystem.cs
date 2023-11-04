using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class WeaponSlotSystem : MonoBehaviour
{
    // Start is called before the first frame update
    public WeaponMovement[] weapons;
    private int currentWeaponIndex = 0;
    void Start()
    {
        SwitchWeapon(currentWeaponIndex);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchWeapon(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwitchWeapon(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SwitchWeapon(2);
        }

    }

    void SwitchWeapon(int newIndex)
    {
        weapons[currentWeaponIndex].gameObject.SetActive(false);

        weapons[newIndex].gameObject.SetActive(true);
        
        currentWeaponIndex = newIndex;
    }
}
