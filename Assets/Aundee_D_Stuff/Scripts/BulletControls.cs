using UnityEngine;

public class BulletControls : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Flame"))
        if (other.CompareTag("Flame") || other.CompareTag("Fire Cluster Spawned"))
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
