using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance; // Singleton instance

    public int currentLevel = 0; // Mevcut seviye
    public Text levelText; // Seviyeyi göstermek için kullanılan TextMeshPro nesnesi

    private void Awake()
    {
        // Singleton pattern: Bu scripti diğer scriptlerden erişilebilir hale getir
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Seviye metnini güncelle
        UpdateLevelText();
    }

    // Seviye metnini güncellemek için fonksiyon
    void UpdateLevelText()
    {
        // TextMeshPro nesnesine mevcut seviyeyi yazdır
        if (levelText != null)
        {
            levelText.text = "Level : " + (currentLevel+1).ToString();
        }
    }

    // Bir sonraki seviyeye geçmek için fonksiyon
    public void NextLevel()
    {
        
        UpdateLevelText();
        SceneManager.LoadScene(currentLevel);
        // Burada diğer seviyeye geçiş veya seviye yükleme işlemleri yapabilirsiniz.
    }
}