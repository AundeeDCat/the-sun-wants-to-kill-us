using UnityEngine;

public class WaterGunControls : MonoBehaviour
{
    public Camera mainCam;
    public float rotationSpeed = 10f;

    void Update()
    {
        WaterGun();
    }

    void WaterGun()
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

        Debug.Log(direction);

    }
}
