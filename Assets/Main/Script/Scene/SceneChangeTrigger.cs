using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 指定コライダーに入ったらシーン移動
/// </summary>
public class SceneChangeTrigger : MonoBehaviour
{
    [Header("移動先シーン名")]
    public string sceneName = "GameOver";

    /// <summary>
    /// Triggerに入った時
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        // Playerタグのみ反応
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}