using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldManager : MonoBehaviour
{
    public int goldAmount
    {
        get => PlayerPrefs.GetInt("playerGold", 0);
        set
        {
            PlayerPrefs.SetInt("playerGold",value);
            UpdateGoldUI();
        }
    }// Toplam altın miktarını saklamak için değişken

    private void Start()
    {
        //PlayerPrefs.DeleteAll();
        UpdateGoldUI();
        
    }

    // Altın eklemek için fonksiyon
    public void AddGold(int amount)
    {
        goldAmount += amount;
        PlayerPrefs.GetInt("playerGold");
        UpdateGoldUI(); // Altın miktarını UI'da güncelle
    }

    // Altın düşürmek için fonksiyon
    public void DecreaseGold(int amount)
    {
        goldAmount -= amount;
        // Eksi altın miktarını engelle
        goldAmount = Mathf.Max(0, goldAmount);
        PlayerPrefs.GetInt("playerGold");
        UpdateGoldUI(); // Altın miktarını UI'da güncelle
    }

    // Altın miktarını UI'da güncellemek için fonksiyon
    void UpdateGoldUI()
    {
        // TextMeshPro bileşenini al ve altın miktarını güncelle
        Text goldText = GetComponent<Text>();
        if (goldText != null)
        {
            goldText.text = goldAmount.ToString();
        }
    }
}