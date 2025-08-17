using UnityEngine;

public class FireControls : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("GAME OVER!");
        }
    }
}
