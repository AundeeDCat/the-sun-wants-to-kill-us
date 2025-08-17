using UnityEngine;

public class StunControls : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Stunned!");
            other.gameObject.GetComponent<PlayerControls>().isStunned = true;
        }
    }
}
