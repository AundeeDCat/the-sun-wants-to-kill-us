using UnityEngine;

public class BulletControls : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Flame"))
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
