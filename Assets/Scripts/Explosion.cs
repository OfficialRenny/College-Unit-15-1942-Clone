using UnityEngine; public class Explosion : MonoBehaviour { void Update() { this.transform.position += (Vector3.down * 3) * Time.deltaTime; } }
