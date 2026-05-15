using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void Start()
    {
        Destroy(gameObject, 3f);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            // ƒXƒRƒA‰ÁZ
            ScoreManager.instance.AddScore(10);

            // Enemyíœ
            Destroy(other.gameObject);

            // ’eíœ
            Destroy(gameObject);
        }
    }
}