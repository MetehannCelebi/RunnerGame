using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using MoreMountains.Feedbacks;
using Unity.Mathematics;
using UnityEngine.Events;

public class EnemyController : MonoBehaviour
{
    [Header("Feedbacks")] public MMFeedbacks SquashAndStrechFeedbacks;
    
    [ SerializeField]private int health = 12; // Düşmanın başlangıç sağlık puanı
    [SerializeField] private GameObject CoinPrefab;

    public TextMeshPro healthText; // Sağlık puanını göstermek için kullanılan TextMeshPro nesnesi
    public int goldReward = 2; // Chest yok edildiğinde kazanılacak altın miktarı


    private void Start()
    {
        UpdateHealthText();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            // feel efektlerini burada çağıraacğım.
            SquashAndStrechFeedbacks?.PlayFeedbacks();

            // Eğer çarpışan obje "Bullet" tag'ine sahipse, düşman hasar alır
            health--;

            // TextMeshPro üzerindeki değeri güncelle
            UpdateHealthText();

            // Mermiyi yok et
            Destroy(collision.gameObject);

            // Eğer düşmanın sağlığı 0'a ulaştıysa, düşmanı yok et
            if (health <= 0)
            {
                DestroyEnemy();
                Instantiate(CoinPrefab,new Vector3(transform.position.x,transform.position.y+.5f,transform.position.z),quaternion.identity);
                RewardGold();
            }
        }
    }

    void UpdateHealthText()
    {
        // TextMeshPro nesnesine düşmanın sağlık puanını yazdır
        if (healthText != null)
        {
            healthText.text = health.ToString();
        }
    }

    void DestroyEnemy()
    {
        // Düşman nesnesini yok et
        //Destroy(gameObject);
        gameObject.SetActive(false);
    }
    
   void RewardGold()
    {
        // Altın yöneticisini bul ve altın miktarını arttır
        GoldManager goldManager = FindObjectOfType<GoldManager>();
        if (goldManager != null)
        {
            goldManager.AddGold(goldReward);
        }
    }
    
    
}