using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;


public class DistanceScript : MonoBehaviour
{
    private int bulletCount = 0; // Çarpan mermi sayısını takip etmek için değişken
    public TextMeshPro bulletCountText; // Mermi sayısını göstermek için kullanılan TextMeshPro nesnesi

    public Vector3 punchRotation = new Vector3(0f, 1f, 0f); // Punch Rotation miktarı
    public float duration = 0.1f; // Efektin süresi
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            // Eğer çarpışan obje "Bullet" tag'ine sahipse, bulletCount'ı artır
            bulletCount++;
            
            
            // GunScript.cs dosyasındaki shootInterval değerini 0.005f kadar azalt
            GunScript gunScript = FindObjectOfType<GunScript>();
            if (gunScript != null)
            {
                gunScript.bulletSpeed = Mathf.Max(0.01f, gunScript.bulletSpeed + 0.1f);
            }
            
            // Shake efekti ekleyerek objeyi yukarı yönlü hareket ettir
            //transform.DOShakePosition(0.5f, new Vector3(0f, 0.1f, 0f), 12, 90f, false);
            
            // DOPunchRotation efektini uygula
            transform.DOPunchRotation(punchRotation, duration);
            // TextMeshPro sayacını güncelle
            UpdateBulletCountText();

            // Mermiyi yok et
            Destroy(collision.gameObject);
        }
    }

    void UpdateBulletCountText()
    {
        // TextMeshPro nesnesine çarpan mermi sayısını yazdır
        if (bulletCountText != null)
        {
            bulletCountText.text = "+ " + bulletCount.ToString();
        }
    }
}