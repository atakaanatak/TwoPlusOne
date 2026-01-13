using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class HealthBar : MonoBehaviour
{
    [Header("Settings")] public int totalHealth = 3;
    public int currentHealth;

    [Header("Images")] public Sprite fullHeart;
    public Sprite emptyHeart;

    [Header("Boxes")] public Image[] hearts;

    void Start()
    {
        currentHealth = totalHealth; 
        UpdateHearts();
    }

    public void TakeDmg(int damage)
    {
        currentHealth -= damage;
        

        UpdateHearts();

       
        PopUpDamageScreen dm = FindFirstObjectByType<PopUpDamageScreen>();
        if (dm != null && currentHealth > 0) 
        {
         
            int whichDamage = totalHealth - currentHealth;
            dm.ShowDmg(whichDamage);
        }
        
    }

    void UpdateHearts()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentHealth)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
        }
    }
    
}