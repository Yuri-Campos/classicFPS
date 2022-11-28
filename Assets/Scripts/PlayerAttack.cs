using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Camera gameCam;
    public int maxAmmo;
    public int ammo;
    public int reserveAmmo;


    // Update is called once per frame
    void Update()
    {
        shoot();
        reload();
    }


    private void shoot()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (ammo == 0)
            {
                Debug.Log("Press TEMP to reload");
                return;
            }
            Ray hitscanRay = gameCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            RaycastHit hitLocation;
            ammo--;
            if (Physics.Raycast(hitscanRay, out hitLocation))
            {
                Debug.Log("Hit: " + hitLocation.transform.name);
            }
            else
            {
                Debug.Log("Miss");
            }
        }
    }

    private void reload()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            if (reserveAmmo <= 0)
            {
                Debug.Log("cant reload: no more ammo");
                return;
            }
            reserveAmmo -= maxAmmo - ammo;
            ammo = maxAmmo - ammo;
            Debug.Log(reserveAmmo);
        }
    }
}
