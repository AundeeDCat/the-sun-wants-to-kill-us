using System.Collections;
using System.Linq;
using UnityEngine;

public class SpawnerControls : MonoBehaviour
{

    public Rigidbody spawned;
    [SerializeField] float spawnedSpeed = 3;
    [SerializeField] float spawnedLifetime = 5f;
    [SerializeField] float spawnLimit = 5;

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

        if (GameObject.FindGameObjectsWithTag(this.gameObject.name + " Spawned").Count() <= spawnLimit)
        {
            Rigidbody clone;

            //Debug.Log(launchSite);

            launchSite = new Vector3(Random.Range(-20, 20), this.transform.position.y, Random.Range(-10, 10));

            if ((launchSite.x > 10 || launchSite.x < -10) && (launchSite.z > 5 || launchSite.z < 5))
            {
                clone = Instantiate(spawned, new Vector3(-50, 0, 0), Quaternion.Euler(90, 0, 0));

                clone.transform.localPosition = launchSite;

                clone.gameObject.SetActive(true);

                clone.linearVelocity = (this.transform.position - launchSite).normalized * spawnedSpeed;

                StartCoroutine(KillSpawned(spawnedLifetime, clone));
            }
            
        }
    }

    private IEnumerator KillSpawned(float time, Rigidbody clone)
    {
        yield return new WaitForSeconds(time);
        Destroy(clone.gameObject);

    }
}
