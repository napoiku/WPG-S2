using System.Collections;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 10f;
    public float fireRate = 0.2f;
    

    private bool isShooting = false;

    void Update()
    {    
        if (Input.GetMouseButtonDown(0) && !isShooting)
        {
            StartCoroutine(ShootContinuously());
        }

        if (Input.GetMouseButtonUp(0))
        {
            isShooting = false;
        }
    

        IEnumerator ShootContinuously(){
        isShooting = true;
        while (isShooting)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 difference = mousePos - transform.position;
            difference.z = 0;
            float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            
            float distance = difference.magnitude;
            Vector2 direction = difference / distance;
            direction.Normalize();

            Shoot(direction, rotationZ);
            yield return new WaitForSeconds(fireRate);
        }
        }

        void Shoot(Vector2 direction, float rotationZ){
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(0, 0, rotationZ));
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.velocity = direction * bulletSpeed;
        }
    }
}