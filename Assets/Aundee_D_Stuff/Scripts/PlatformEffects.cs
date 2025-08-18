using UnityEngine;
using System.Collections;
using UnityEditor.Timeline;

public class PlatformEffects : MonoBehaviour
{

    float gravityScale = -50;

    float stunCooldown = 3;
    float stunActiveTime = 3;
    bool isStunActive = false;

    float featherFadeTime = 3;

    float reloadSpeed = 1;

    void Start()
    {
        if (this.gameObject.CompareTag("Storm")) StartCoroutine(StormActive(stunActiveTime));
    }



    void OnTriggerEnter(Collider other)
    {
        if (this.gameObject.CompareTag("Cosmos") && other.CompareTag("Player"))
        {
            Physics.gravity = new Vector3(0, gravityScale / 10, 0);

            SpawnerControls.inCosmos = true;
        }

        if (this.gameObject.CompareTag("Sky") && other.CompareTag("Player"))
        if (this.gameObject.CompareTag("Feather") && other.CompareTag("Player"))
        {
            exitedFeather = false;
            StartCoroutine(FeatherFade(featherFadeTime, other));
        }

        if (this.gameObject.CompareTag("Ground") && other.CompareTag("Player"))
        {
            SpawnerControls.inGround = true;
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

        if (this.gameObject.CompareTag("Feather") && other.CompareTag("Player"))
        {
            exitedFeather = true;
        }

        if (this.gameObject.CompareTag("Ground") && other.CompareTag("Player"))
        {
            SpawnerControls.inGround = false;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (this.gameObject.CompareTag("Storm") && other.CompareTag("Player") && isStunActive)
        {
            Debug.Log("Stunned!");
            other.gameObject.GetComponent<PlayerControls>().isStunned = true;
        }

        if (this.gameObject.CompareTag("Rain") && other.CompareTag("Player") && !isReloading)
        {
            StartCoroutine(AmmoRefill(reloadSpeed));
        }
    }


    private IEnumerator StormActive(float time)
    {
        yield return new WaitForSeconds(time);
        StartCoroutine(StormInactive(stunCooldown));
        isStunActive = false;
    }

    private IEnumerator StormInactive(float time)
    {
        yield return new WaitForSeconds(time);
        StartCoroutine(StormActive(stunActiveTime));
        isStunActive = true;
    }

    bool exitedFeather = false;
    private IEnumerator FeatherFade(float time, Collider other)
    {
        yield return new WaitForSeconds(time);
        this.gameObject.transform.parent.gameObject.SetActive(false);

        if (!exitedFeather)
        {
            other.gameObject.GetComponent<PlayerControls>().northBounds = true;
            other.gameObject.GetComponent<PlayerControls>().southBounds = true;
            other.gameObject.GetComponent<PlayerControls>().eastBounds = true;
            other.gameObject.GetComponent<PlayerControls>().westBounds = true;
        }
    }

    bool isReloading = false;
    private IEnumerator AmmoRefill(float time)
    {
        isReloading = true;

        yield return new WaitForSeconds(time);

        WaterGunControls.ReloadAmmo();
        isReloading = false;
    }
}
