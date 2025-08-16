using System.Collections;
using System.Linq;
using UnityEngine;

public class SpawnerControls : MonoBehaviour
{
    [SerializeField] float spawnDelayMax = 3;
    [SerializeField] float spawnDelayMin = 1;

    public Rigidbody spawned;
    float spawnedSpeed = 3;
    float spawnedLifetime = 5f;
    float spawnLimit = 5;

    public bool isSpawning = false;

    public bool isCozmosSpawner;
    public static bool inCosmos;

    Vector3 launchSite = new Vector3(15, 0, 0);

    void Update()
    {
        if (isCozmosSpawner && inCosmos) SpawnItem();
    }

    public void SpawnItem()
    {
       //Debug.Log(this.gameObject.name + " Spawned");

        if (GameObject.FindGameObjectsWithTag(this.gameObject.name + " Spawned").Count() <= spawnLimit)
        {
            //Debug.Log("Spawning " + spawned.gameObject.name);
            Rigidbody clone;

        Debug.Log(launchSite);

        launchSite = new Vector3(Random.Range(-10, 10), this.transform.position.y , Random.Range(-10, 10));

        clone = Instantiate(spawned, new Vector3 (-50, 0, 0), Quaternion.Euler(90, 0, 0));

        clone.transform.localPosition = launchSite;

        clone.gameObject.SetActive(true);

        clone.linearVelocity = (this.transform.position - launchSite).normalized * spawnedSpeed ;

        StartCoroutine(KillSpawned(spawnedLifetime, clone));
        }
    }
    
    private IEnumerator KillSpawned(float time, Rigidbody clone)
    {
        yield return new WaitForSeconds(time);
        Destroy(clone.gameObject);

    }
}
