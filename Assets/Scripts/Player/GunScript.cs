using UnityEngine;
using DG.Tweening;
public class GunScript : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float bulletSpeed = 10f;
    public float bulletLifetime = 3f;
    
    public GameObject effectPrefab;
    public Transform effectSpawnPoint;
    //public float effectDuration = 0.1f;


    private float shootTimer = 0f;
    public float shootInterval = 0.5f; // Mermi atma aralığı (saniye cinsinden)

    void Update()
    {
        // Zamanlayıcıyı güncelle
        shootTimer += Time.deltaTime;

        // Eğer ateş etme zamanı geldiyse
        if (shootTimer >= shootInterval)
        {
            // Mermiyi oluştur
            //GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
           
            // Mermiyi oluştur
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.Euler(90f, 0f, 0f));

            
            Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();

            // Mermiye ileri doğru hız ver
            bulletRigidbody.velocity = bulletSpawnPoint.forward * bulletSpeed;

            // Mermiye belirli bir süre sonra yok olma komutunu ver
            Destroy(bullet, bulletLifetime);
            
            // Efekti oluştur
            GameObject effect = Instantiate(effectPrefab, effectSpawnPoint.position, effectSpawnPoint.rotation);

            // Efekti belirli bir süre sonra yok olma komutunu ver
            Destroy(effect, shootInterval);

            // Zamanlayıcıyı sıfırla
            shootTimer = 0f;
            
        }
    }
    
   
}