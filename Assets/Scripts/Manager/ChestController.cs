using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChestController : MonoBehaviour
{
    [SerializeField] private int health = 7; // Chestin başlangıç sağlık puanı
    public TextMeshPro healthText; // Sağlık puanını göstermek için kullanılan TextMeshPro nesnesi

    public int goldReward = 10; // Chest yok edildiğinde kazanılacak altın miktarı

    private void Start()
    {
        healthText.text = health.ToString();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            // Eğer çarpışan obje "Bullet" tag'ine sahipse, chestin sağlık puanını azalt
            health--;

            // TextMeshPro üzerindeki değeri güncelle
            UpdateHealthText();

            // Mermiyi yok et
            Destroy(collision.gameObject);

            // Eğer chestin sağlığı 0'a ulaştıysa, chesti yok et
            if (health <= 0)
            {
                DestroyChest();
                RewardGold();
            }
        }
    }

    void UpdateHealthText()
    {
        // TextMeshPro nesnesine chestin sağlık puanını yazdır
        if (healthText != null)
        {
            healthText.text =health.ToString();
        }
    }

    void DestroyChest()
    {
        // Chest nesnesini yok et
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