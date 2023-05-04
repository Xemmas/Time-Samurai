using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    //bullet
    public GameObject bullet;
    public float shootForce;

    //bools
    bool shooting, readyToShoot, reloading;

    //Gun stats
    public float timeBetweenShooting, spread, range, reloadTime, timeBetweenShots;
    public int magSize, bulletsPerTap;
    public bool allowButtonHold;
    int ammoLeft, ammoShot;

    //Reference
    //public Camera Cam;
    public Transform attackPoint;

    // Start is called before the first frame update
    void Start()
    {
        ammoLeft = magSize;
        readyToShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        MyInput();
    }

    private void Shoot()
    {
        readyToShoot = false;   
        //Spawn bullet at attack point
        GameObject currentBullet = Instantiate(bullet, attackPoint.position, attackPoint.rotation);
        Rigidbody2D rb = currentBullet.GetComponent<Rigidbody2D>();

        rb.AddForce(attackPoint.up * shootForce, ForceMode2D.Impulse);

        ammoLeft--;
        ammoShot--;
        Invoke("ResetShot", timeBetweenShooting);

        if (ammoShot > 0 && ammoLeft > 0)
        {
            Invoke("Shoot", timeBetweenShots);
        }
    }

    public void MyInput()
    {
        if (allowButtonHold) shooting = Input.GetKey(KeyCode.Mouse1);
        else shooting = Input.GetKeyDown(KeyCode.Mouse1);

        if (Input.GetKeyDown(KeyCode.R) && ammoLeft < magSize && !reloading && this.gameObject.activeSelf)
        {
            Reload();
        } 
        
        //Shoot
        if (readyToShoot && shooting && !reloading &&  ammoLeft > 0)
        {
            ammoShot = bulletsPerTap;
            Shoot();
        }
    }

    private void ResetShot()
    {
        readyToShoot = true;
    }

    private void Reload()
    {
        reloading = true;
        Invoke("ReloadFinished", reloadTime);
    }

    private void ReloadFinished()
    {
        ammoLeft = magSize;
        reloading = false;
    }
}
