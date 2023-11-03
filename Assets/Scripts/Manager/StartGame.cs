using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class StartGame : MonoBehaviour
{
    [FormerlySerializedAs("startCanvas")] public GameObject StartPanel;

    void Start()
    {
        // Oyun başlangıcında Time.timeScale değerini sıfıra ayarla
        Time.timeScale = 0f;
        // Canvas'ı aktif et
        StartPanel.gameObject.SetActive(true);
    }

    // Oyunu başlatan fonksiyon
    public void StartGameButton()
    {
        // Time.timeScale değerini tekrar 1 yaparak oyunu başlat
        Time.timeScale = 1f;
        // Canvas'ı devre dışı bırak
        StartPanel.gameObject.SetActive(false);
        
    }
}