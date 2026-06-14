using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private HealthModule playerHealth;

    void Awake()
    {
        playerHealth.OnDeath += ShowGameOver;
    }

    public void UpdateHealthText(int health)
    {
        healthText.text = health.ToString() + "%";
    }

    public void ShowGameOver()
    {
        healthText.text = "YOU ARE DEAD!";
    }
}
