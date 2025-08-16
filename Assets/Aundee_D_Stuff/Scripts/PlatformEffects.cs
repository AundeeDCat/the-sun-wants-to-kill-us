using UnityEngine;

public class PlatformEffects : MonoBehaviour
{
    
    float gravityScale = -50;
    void OnTriggerEnter(Collider other)
    {
        if (this.gameObject.CompareTag("Cosmos"))
        {
            Debug.Log("In Cosmos");
            Physics.gravity = new Vector3(0, gravityScale / 10, 0);

            SpawnerControls.inCosmos = true;
        }

        else
        {
            Debug.Log("Not in Cosmos");
            Physics.gravity = new Vector3(0, gravityScale, 0);

            SpawnerControls.inCosmos = false;
        }
    }
}
