using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// ボタンを押したらシーン移動
/// </summary>
public class SceneButton : MonoBehaviour
{
    [Header("移動先シーン名")]
    public string sceneName = "GameScene";

    /// <summary>
    /// ボタン押下時
    /// </summary>
    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}