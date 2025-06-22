using UnityEngine;

public class ElevationEntry : MonoBehaviour {
    public Collider2D[] mountainColliders;
    public Collider2D[] boundaryColliders;
        
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            foreach (Collider2D mountain in mountainColliders) {
                mountain.enabled = false;
            }
            foreach (Collider2D boundary in boundaryColliders) {
                boundary.enabled = true;
            }
            other.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 15;
            Debug.Log("[Entry] OnTriggerEnter2D");
        }
    }
}