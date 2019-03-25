using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public Sprite[] randomSprites;
    public GameObject[] spawnLocations;
    public GameObject enemy;
    public GameObject player;
    public float maxSpawnTime;
    public int enemiesToSpawn;
    public static bool bossDestroyed;
    public static bool bossSpawned;

    private void Awake()
    {
        bossDestroyed = false;
        bossSpawned = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown("u"))
        {
            SpawnBoss();
        }
    }

    void Start () {
        enemiesToSpawn = Level.curLevel * 20;
        Invoke("SpawnEnemy", 1f);
	}

    public void SpawnEnemy() {
        if (!player.GetComponent<Player>().isRespawning || !Framework.areWeFading) {
            Vector3 randomSpawn = spawnLocations[(int)Mathf.Floor(spawnLocations.Length * Random.value)].transform.position;
            GameObject randomEnemy = Instantiate(enemy, randomSpawn, new Quaternion()) as GameObject;
            randomEnemy.transform.parent = null;
            randomEnemy.GetComponent<Enemy>().player = player;
            randomEnemy.GetComponent<SpriteRenderer>().sprite = GetRandomSprite();
            if (Level.curLevel > 5 && !bossSpawned && !bossDestroyed && player.GetComponent<Player>().score > Level.curLevel * 1000) SpawnBoss();
        }
        Invoke("SpawnEnemy", Random.value * maxSpawnTime);
    }

    public void SpawnBoss()
    {
        Vector3 randomSpawn = spawnLocations[(int)Mathf.Floor(spawnLocations.Length * Random.value)].transform.position;
        GameObject randomEnemy = Instantiate(enemy, randomSpawn, new Quaternion()) as GameObject;
        randomEnemy.transform.parent = null;
        randomEnemy.GetComponent<Enemy>().player = player;
        randomEnemy.GetComponent<SpriteRenderer>().sprite = GetRandomSprite();
        randomEnemy.GetComponent<Enemy>().isBoss = true;
        bossSpawned = true;
    }

    Sprite GetRandomSprite() {
        Sprite sprite = randomSprites[(int)Mathf.Floor(randomSprites.Length * Random.value)];
        if (sprite == player.GetComponent<SpriteRenderer>().sprite) {
            return GetRandomSprite();
        }
        return sprite;
    }
}
