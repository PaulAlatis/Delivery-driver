using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
  [SerializeField] Color32 hasPackageColor = new Color32(1,1,1,1);
  [SerializeField] Color32 noPackageColor = new Color32(1,1,1,1);
  bool hasPackage;
  [SerializeField]  float DestroyDelay = 0.5f;

  SpriteRenderer spriteRenderer;

  void Start()
  {
    spriteRenderer = GetComponent<SpriteRenderer>();
  }

   void OnCollisionEnter2D(Collision2D other) 
   {
     Debug.Log("Collision Detected");
   }

   void OnTriggerEnter2D(Collider2D other) 
   {
    if(other.tag == "Package" && !hasPackage)
    {
      Debug.Log("Package Acquired");
      hasPackage = true;
      spriteRenderer.color = hasPackageColor;
      Destroy(other.gameObject,DestroyDelay);
    }
    if(other.tag == "Customer" && hasPackage  == true)
    {
      Debug.Log("Package Delivered");
      hasPackage = false;
      spriteRenderer.color = noPackageColor;
    }
   }
}
