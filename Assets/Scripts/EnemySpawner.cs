using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public Sprite[] randomSprites;
    public GameObject[] spawnLocations;
    public GameObject enemy;
    public GameObject player;
    public float maxSpawnTime;

    void Start () {
        Invoke("SpawnEnemy", 1f);
	}

    void SpawnEnemy() {
        System.Random random = new System.Random();
        Transform randomSpawn = spawnLocations[(int)Mathf.Floor(spawnLocations.Length * random.Next(0, 1))].transform;
        GameObject randomEnemy = Instantiate(enemy, randomSpawn, true) as GameObject;
        randomEnemy.transform.parent = null;
        randomEnemy.GetComponent<Enemy>().player = player;
        randomEnemy.GetComponent<SpriteRenderer>().sprite = randomSprites[(int)Mathf.Floor(randomSprites.Length * Random.value)];
        Invoke("SpawnEnemy", Random.value * maxSpawnTime);
    }
}
