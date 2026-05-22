using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerHP : MonoBehaviour
{
    public int maxHP = 100;
    public int currentHP;

    public int damageAmount = 5; // 落下Prefabからのダメージ
    public float damageInterval = 1f; // 1秒間隔でダメージ

    public TextMeshProUGUI hpText;

    private float nextDamageTime;
    public string gameOverSceneName = "GameOver";

    private void Start()
    {
        currentHP = maxHP;
        UpdateHPText();
    }

    // EnemyタグのPrefabに触れている間
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
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
        UpdateHPText();
        Debug.Log("Player HP : " + currentHP);

        if (currentHP <= 0)
        {
            Die();
        }
    }

    void UpdateHPText()
    {
        if (hpText != null)
            hpText.text = "HP : " + currentHP;
    }

    void Die()
    {
        SceneManager.LoadScene(gameOverSceneName);
    }
}