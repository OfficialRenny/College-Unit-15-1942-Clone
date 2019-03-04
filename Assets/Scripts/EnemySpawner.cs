using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public Sprite[] randomSprites;
    public GameObject[] spawnLocations;
    public GameObject enemy;
    public GameObject player;
    public float maxSpawnTime;
    public int enemiesToSpawn;

    void Start () {
        enemiesToSpawn = Level.curLevel * 20;
        Invoke("SpawnEnemy", 1f);
	}

    void SpawnEnemy() {
        if (!player.GetComponent<Player>().isRespawning || !Framework.areWeFading) {
            Vector3 randomSpawn = spawnLocations[(int)Mathf.Floor(spawnLocations.Length * Random.value)].transform.position;
            GameObject randomEnemy = Instantiate(enemy, randomSpawn, new Quaternion()) as GameObject;
            randomEnemy.transform.parent = null;
            randomEnemy.GetComponent<Enemy>().player = player;
            randomEnemy.GetComponent<SpriteRenderer>().sprite = GetRandomSprite();
        }
        Invoke("SpawnEnemy", Random.value * maxSpawnTime);
    }

    Sprite GetRandomSprite() {
        Sprite sprite = randomSprites[(int)Mathf.Floor(randomSprites.Length * Random.value)];
        if (sprite == player.GetComponent<SpriteRenderer>().sprite) {
            return GetRandomSprite();
        }
        return sprite;
    }
}
