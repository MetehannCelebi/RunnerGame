using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PurchaseManager : MonoBehaviour
{
    public Button purchaseButton1;
    public Button purchaseButton2;
    public GoldManager goldManager;
    public TextMeshProUGUI button1Text;
    public TextMeshProUGUI button2Text;
    private int button1Value; // İlk buton üzerindeki değer
    private int button2Value; // İkinci buton üzerindeki değer
    public GunScript gunScript; // GunScript'e referans

    private void Start()
    {
        // PlayerPrefs'tan buton değerlerini al
        button1Value = PlayerPrefs.GetInt("Button1Value", 10);
        button2Value = PlayerPrefs.GetInt("Button2Value", 10);

        // Butonların tıklanabilirlik durumunu kontrol etmek için listenerları ekleyin
        purchaseButton1.onClick.AddListener(PurchaseButton1Clicked);
        purchaseButton2.onClick.AddListener(PurchaseButton2Clicked);
        
        
        //buton 1 in değerini 10 a bölücez ve çıkan sonucu -0.005 ile çarpıp gunscriptteki gunScript.shootInterval - 0.005f  formülünü uygulayacağız.
        // buton 2 için de aynı işlemi yapacağız böylece algoritmamız kurulmuş olacak 0.05f


        float buyFirerate = (button1Value / 10) * 0.005f;
        gunScript.shootInterval -= buyFirerate;

        float buyDistance = (button1Value / 10) * 0.05f;
        gunScript.bulletSpeed += buyDistance;
    }

    private void Update()
    {
        // Butonların tıklanabilirlik durumunu kontrol et
        purchaseButton1.interactable = goldManager.goldAmount >= button1Value;
        purchaseButton2.interactable = goldManager.goldAmount >= button2Value;
        
        // Buton textlerini güncelle
        button1Text.text = button1Value.ToString();
        button2Text.text = button2Value.ToString();
    }

    void PurchaseButton1Clicked()
    {
        // Altın miktarını artır ve buton değerini kaydet
        goldManager.DecreaseGold(button1Value);
        button1Value += 10;
        PlayerPrefs.SetInt("Button1Value", button1Value);
        // GunScript'teki shootInterval değerini azalt
        gunScript.shootInterval -= 0.005f;
    }

    void PurchaseButton2Clicked()
    {
        // Altın miktarını artır ve buton değerini kaydet
        goldManager.DecreaseGold(button2Value);
        button2Value += 10;
        PlayerPrefs.SetInt("Button2Value", button2Value);
        // GunScript'teki bulletSpeed değerini artır
        gunScript.bulletSpeed += 0.1f;
    }
}