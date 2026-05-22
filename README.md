# Rain Escape

Unity 6 + URP + 新 Input System を使用した
3D回避アクションゲームです。

空から大量に降ってくる危険な雨を避けながら、
ゴール地点を目指します。

Unityプログラム授業
「Unity Game A Week」向け教材として制作しています。


# ゲーム概要

プレイヤーは降り続ける危険なオブジェクトを避けながら、
ゴール地点を目指します。

Unityの3D物理演算（Rigidbody）を利用した、
Unity基礎学習向けの回避アクションゲームです。



# 基本ルール

* WASD / 左スティックで移動
* Space / Aボタンでジャンプ
* 雨に触れるとHP減少
* HPが0になるとゲームオーバー
* ゴールに到達するとクリア



# 使用環境

* Unity 6
* URP
* 新 Input System
* TextMeshPro
* 3D Physics（Rigidbody）



# シーン構成

 Scene     内容      

Title    タイトル画面  
Game   　ゲーム本編  
GameOver ゲームオーバー 
Clear    クリア画面   



# 主なスクリプト

Script                 内容        

Spawner.cs             雨Prefab生成 
EnemyPrefab.cs         落下物制御     
PlayerController.cs    プレイヤー移動   
PlayerHP.cs            HP管理      
SceneButton.cs         ボタンシーン遷移  
SceneChangeTrigger.cs 　ゴール判定     
BGMManager.cs          BGM再生     



# プレイヤー仕様

## 移動

新 Input System の
`InputAction.CallbackContext`
を利用して入力取得。

```csharp
public void OnMove(InputAction.CallbackContext context)
{
    moveInput = context.ReadValue<Vector2>();
}
```

Rigidbody の velocity を利用して移動。

```csharp
rb.linearVelocity = new Vector3(
    move.x * moveSpeed,
    rb.linearVelocity.y,
    move.z * moveSpeed
);
```



## ジャンプ

Input System のボタン入力でジャンプ。

```csharp
public void OnJump(InputAction.CallbackContext context)
{
    if (context.performed && isGrounded)
    {
        rb.linearVelocity = new Vector3(
            rb.linearVelocity.x,
            jumpForce,
            rb.linearVelocity.z
        );
    }
}
```



## 接地判定

GroundタグとのCollision判定を利用。

```csharp
OnCollisionEnter()
```



# 雨生成仕様

Spawnerが一定範囲内に
ランダムでPrefabを大量生成。

```csharp
Instantiate(prefabs[index], spawnPos, Quaternion.identity);
```

BoxCollider範囲を利用して
ランダム座標を決定。



# ゴール判定

Goalオブジェクトに Trigger Collider を設定。

```txt
Is Trigger : ON
```

Playerが接触すると：

```csharp
SceneManager.LoadScene("Clear");
```



# ゲームオーバー条件

* HPが0になる
* 危険な雨に接触し続ける



# 今後の追加予定

* 雨エフェクト強化
* スコアシステム
* ステージ追加
* SE / 演出追加
* 難易度調整
* UIアニメーション
