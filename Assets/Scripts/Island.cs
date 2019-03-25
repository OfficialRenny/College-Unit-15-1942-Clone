using UnityEngine;

public class Island : MonoBehaviour
{
    public GameObject[] spawnLocations;
    public GameObject island;
    public float maxTime = 5f;

    void Start()
    {
        Invoke("SpawnIsland", 0f);
    }

    void SpawnIsland()
    {
        Vector3 randomSpawn = spawnLocations[Random.Range(0, 5)].transform.position;
        GameObject new_island = Instantiate(island, randomSpawn, new Quaternion()) as GameObject;
        Randomness(new_island);
        new_island.GetComponent<Rigidbody2D>().velocity = Vector3.down * 3f;
        Invoke("SpawnIsland", Random.Range(1f, maxTime));
    }

    private void Update()
    {
        if (this.transform.position.y < -15f) Destroy(gameObject);
    }

    void Randomness(GameObject i)
    {
        float rndScale = Random.Range(0.5f, 3f);
        float rndRot = Random.Range(0f, 360f);
        i.transform.localScale = new Vector3(rndScale, rndScale, rndScale);
        i.transform.rotation = new Quaternion(0f, 0f, 1f, Mathf.Deg2Rad * rndRot);
    }
}
