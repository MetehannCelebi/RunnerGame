using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    // Start is called before the first frame update
    // Merminin herhangi bir nesneye çarptığında yok olmasını sağlayın.
    // Merminin çarptığı nesnenin tag'ini kontrol etmek için bir değişken oluşturun.
    public string targetTag = "Target";

    // Merminin çarpışma davranışını kontrol etmek için `OnCollisionEnter()` metodunu override edin.
    protected void OnCollisionEnter(Collision collision)
    {
        // Merminin çarptığı nesnenin tag'ini kontrol edin.
        if (collision.gameObject.tag == targetTag)
        {
            // Mermini yok edin.
            Destroy(gameObject);
        }
        
        
    }
}
