using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab; // 生成するプレハブ

    public float spawnMinRangeZ = 0f;   // 敵の生成位置のZ軸の最小値
    public float spawnMaxRangeZ = 5f;   // 敵の生成位置のZ軸の最大値
    public float spawnInterval = 2f; // 敵を生成する間隔

    private float timer; // タイマー
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // タイマーを更新
        timer += Time.deltaTime;

        // タイマーが生成間隔を超えたら敵を生成
        if (timer >= spawnInterval)
        {
            SpawnEnemy(); // 敵を生成する関数を呼び出す
            timer = 0f; // タイマーをリセット
        }

    }

    void SpawnEnemy()
    {
        //座標は（0,0）基準
        Vector2 spawnPosition = new Vector2(transform.position.x, transform.position.y); // 生成位置を設定
        spawnPosition.y += Random.Range(spawnMinRangeZ, spawnMaxRangeZ); // Y軸にランダムなオフセットを追加

        Vector2 enemyMoveVector;    // 敵の移動方向ベクトル
        if(spawnPosition.x > transform.position.x)
        {
            enemyMoveVector = Vector2.left; // 右から生成された場合は左に移動
        }
        else
        {
            enemyMoveVector = Vector2.right; // 左から生成された場合は右に移動
        }

        //エネミーの生成
        var enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity); // プレハブを生成
        
        //エネミーの移動方向を設定
        

    }
}
