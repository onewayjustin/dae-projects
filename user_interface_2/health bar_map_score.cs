using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    [Header("HUD Components")]
    public Slider healthBar;
    public Text scoreText;
    public GameObject miniMap;

    [Header("Health Settings")]
    public float maxHealth = 100f;
    public float regenRate = 5f;
    public Image damageFlashImage;
    public Color flashColor = new Color(1, 0, 0, 0.4f);
    public float flashSpeed = 5f;

    private float currentHealth;
    private int score = 0;
    private bool isDamaged;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateScoreText();
    }

    void Update()
    {
        // Health regen
        if (currentHealth < maxHealth)
        {
            currentHealth += regenRate * Time.deltaTime;
            currentHealth = Mathf.Min(currentHealth, maxHealth);
            UpdateHealthBarSmooth();
        }

        // Damage flash effect
        if (isDamaged)
        {
            damageFlashImage.color = flashColor;
        }
        else
        {
            damageFlashImage.color = Color.Lerp(damageFlashImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        isDamaged = false;

        // Demo controls
        if (Input.GetKeyDown(KeyCode.H)) TakeDamage(15);
        if (Input.GetKeyDown(KeyCode.S)) AddScore(100);
        if (Input.GetKeyDown(KeyCode.M)) ToggleMiniMap();
    }

    public void TakeDamage(float amount)
    {
        currentHealth = Mathf.Max(0, currentHealth - amount);
        isDamaged = true;
        UpdateHealthBarSmooth();
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreText();
    }

    void UpdateHealthBarSmooth()
    {
        healthBar.value = currentHealth / maxHealth;
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString("N0");
    }

    public void ToggleMiniMap()
    {
        miniMap.SetActive(!miniMap.activeSelf);
    }
}
