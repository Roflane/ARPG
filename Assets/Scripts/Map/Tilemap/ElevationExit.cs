using UnityEngine;

public class ElevationExit : MonoBehaviour {
    public Collider2D[] mountainColliders;
    public Collider2D[] boundaryColliders;
        
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            foreach (Collider2D mountain in mountainColliders) {
                mountain.enabled = true;
            }
            foreach (Collider2D boundary in boundaryColliders) {
                boundary.enabled = false;
            }
            other.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;
            Debug.Log("[Exit] OnTriggerEnter2D");
        }   
    }
}