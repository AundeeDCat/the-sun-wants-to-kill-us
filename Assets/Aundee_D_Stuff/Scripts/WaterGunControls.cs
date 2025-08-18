using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class WaterGunControls : MonoBehaviour
{
    public Camera mainCam;
    float rotationSpeed = 10f;

    public Rigidbody bullet;
    float bulletSpeed = 25;
    float bulletLifetime = 3;

    float shootCooldown = 0.5f;
    int ammoAmount = 10;
    int ammoLimit = 20;


    void Update()
    {
        Aim();
        Shoot();
    }

    void Aim()
    {
        Vector3 mousePos = Input.mousePosition;

        Vector2 normPos = new Vector2
        (
            (mousePos.x / Screen.width) - 0.5f,
            (mousePos.y / Screen.height) - 0.5f
        );

        Vector3 direction = new Vector3(normPos.x, normPos.y, 0f).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        Quaternion targetRot = Quaternion.Euler(90f, 0f, angle);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, rotationSpeed * Time.deltaTime);
    }

    void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Rigidbody clone;

            clone = Instantiate(bullet, transform.position, this.gameObject.transform.rotation);

            clone.gameObject.SetActive(true);

            clone.linearVelocity = transform.TransformDirection(Vector3.right * bulletSpeed);

            StartCoroutine(KillBullet(bulletLifetime, clone));
        }
    }


    private IEnumerator KillBullet(float time, Rigidbody clone)
    {
        yield return new WaitForSeconds(time);
        Destroy(clone.gameObject);

    }
}
