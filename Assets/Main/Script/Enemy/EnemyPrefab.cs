using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyPrefab : MonoBehaviour
{
    public string sceneToLoad = "GameOver";

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
        else if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}