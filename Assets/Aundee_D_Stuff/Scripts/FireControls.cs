using UnityEngine;

public class FireControls : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("GAME OVER!");
        }
    }
}
