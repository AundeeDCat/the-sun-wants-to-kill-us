using UnityEngine;

public class PlatformEffects : MonoBehaviour
{

    float gravityScale = -50;
    void OnTriggerEnter(Collider other)
    {
        if (this.gameObject.CompareTag("Cosmos") && other.CompareTag("Player"))
        {
            Physics.gravity = new Vector3(0, gravityScale / 10, 0);

            SpawnerControls.inCosmos = true;
        }

        if (this.gameObject.CompareTag("Sky") && other.CompareTag("Player"))
        {

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (this.gameObject.CompareTag("Cosmos") && other.CompareTag("Player"))
        {
            Physics.gravity = new Vector3(0, gravityScale, 0);

            SpawnerControls.inCosmos = false;
        }
        
        if (this.gameObject.name == "Sky" && other.CompareTag("Player"))
        {

        }
    }
}
