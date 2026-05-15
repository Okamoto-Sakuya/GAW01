using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerHP : MonoBehaviour
{
    public int maxHP = 100;
    public int currentHP;

    public int damageAmount = 5;

    // HP表示用
    public TextMeshProUGUI hpText;

    // ダメージ間隔
    public float damageInterval = 1f;

    private float nextDamageTime;

    public string gameOverSceneName = "GameOver";

    private void Start()
    {
        currentHP = maxHP;

        UpdateHPText();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (Time.time >= nextDamageTime)
            {
                TakeDamage(damageAmount);

                nextDamageTime = Time.time + damageInterval;
            }
        }
    }

    void TakeDamage(int damage)
    {
        currentHP -= damage;

        // HP表示更新
        UpdateHPText();

        Debug.Log("Player HP : " + currentHP);

        if (currentHP <= 0)
        {
            Die();
        }
    }

    void UpdateHPText()
    {
        hpText.text = "HP : " + currentHP;
    }

    void Die()
    {
        SceneManager.LoadScene(gameOverSceneName);
    }
}