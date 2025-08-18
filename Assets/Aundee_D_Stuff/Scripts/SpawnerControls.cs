using System.Collections;
using System.Linq;
using UnityEngine;

public class SpawnerControls : MonoBehaviour
{
    [SerializeField] float spawnDelayMax = 3;
    [SerializeField] float spawnDelayMin = 1;

    public Rigidbody spawned;
    public Rigidbody spawnedTargeter;
    public GameObject spawnedCluster;
    [SerializeField] float spawnedSpeed = 3;
    [SerializeField] float spawnedLifetime = 5f;
    [SerializeField] float spawnLimit = 5;

    public bool isSpawning = false;
    [SerializeField] bool isSpawning = false;

    public bool isCozmosSpawner;
    public static bool inCosmos;

    public bool isGroundSpawner;
    public static bool inGround;

    Vector3 launchSite = new Vector3(15, 0, 0);

    void Update()
    {
        if (isCozmosSpawner && inCosmos) SpawnItem();
        if (isCozmosSpawner && inCosmos) SpawnTargetingItem();

        if (isGroundSpawner && inGround && !isSpawning && GameObject.FindGameObjectsWithTag(this.gameObject.name + " Spawned").Count() == 1)
            StartCoroutine(SpawnClusterItem(spawnedSpeed));
    }

    public void SpawnItem()
    public void SpawnTargetingItem()
    {

        if (GameObject.FindGameObjectsWithTag(this.gameObject.name + " Spawned").Count() <= spawnLimit)
        {
            Rigidbody clone;

            //Debug.Log(launchSite);

            launchSite = new Vector3(Random.Range(-20, 20), this.transform.position.y, Random.Range(-10, 10));

            if ((launchSite.x > 10 || launchSite.x < -10) && (launchSite.z > 5 || launchSite.z < 5))
            {
                clone = Instantiate(spawned, new Vector3(-50, 0, 0), Quaternion.Euler(90, 0, 0));
                clone = Instantiate(spawnedTargeter, new Vector3(-50, 0, 0), Quaternion.Euler(90, 0, 0));

                clone.transform.localPosition = launchSite;

                clone.gameObject.SetActive(true);

                clone.linearVelocity = (this.transform.position - launchSite).normalized * spawnedSpeed;

                StartCoroutine(KillSpawned(spawnedLifetime, clone));
                StartCoroutine(KillSpawnedTargeter(spawnedLifetime, clone));
            }
            
        }
    }

    private IEnumerator KillSpawned(float time, Rigidbody clone)
    IEnumerator SpawnClusterItem(float time)
    {
        isSpawning = true;

        yield return new WaitForSeconds(time);
        
        GameObject clone;
        
        isSpawning = false;

        for (int i = 0; i < spawnLimit; i++)
        {
            clone = Instantiate(spawnedCluster, new Vector3(0, 0, 0), Quaternion.Euler(90, 0, 0));

            clone.transform.SetParent(this.gameObject.transform);

            launchSite = new Vector3(Random.Range(-2f, 2f), Random.Range(-2f, 2f), 0);

            clone.transform.localPosition = launchSite;

            clone.gameObject.SetActive(true);

            StartCoroutine(KillSpawnedCluster(spawnedLifetime, clone));
        }
            
    }

    private IEnumerator KillSpawnedTargeter(float time, Rigidbody clone)
    {
        yield return new WaitForSeconds(time);
        Destroy(clone.gameObject);

    }
    private IEnumerator KillSpawnedCluster(float time, GameObject clone)
    {
        yield return new WaitForSeconds(time);
        Destroy(clone.gameObject);

    }
}
