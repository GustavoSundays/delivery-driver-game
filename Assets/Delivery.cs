using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    
    [SerializeField] Color32 hasPackageColor = new Color32(0, 255, 0, 255);
    [SerializeField] Color32 noPackageColor = new Color32(255, 255, 255, 255);
    [SerializeField] float destroyDelay = 0.5f;

    SpriteRenderer spriteRenderer;

    bool hasPackage = false;

    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        
        Debug.Log("Ai");
    }

    private void OnTriggerEnter2D(Collider2D other) {
        
        if (other.tag == "Package" && !hasPackage) {
            Debug.Log("pegou");
            hasPackage = true;
            Destroy(other.gameObject, destroyDelay);
            spriteRenderer.color = hasPackageColor;
        } 
        
        if (other.tag == "Customer" && hasPackage) {
            Debug.Log("entregue");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
        }
    }
}
