using UnityEngine;

public class LandingPredictor : MonoBehaviour
{
    [SerializeField] private Rigidbody2D targetRb;
    [SerializeField] private float groundY = -4f;

    private void LateUpdate()
    {
        // 現在のパラメータを取得
        float startY = targetRb.position.y;
        float startX = targetRb.position.x;
        float velY = targetRb.linearVelocity.y;
        float velX = targetRb.linearVelocity.x;

        // Unityの重力加速度（通常は -9.81 * gravityScale）
        float gravity = Physics2D.gravity.y * targetRb.gravityScale;

        // すでに地面より下にいる場合や、重力ゼロの場合は計算不可なので今のXを返す
        if (startY <= groundY || gravity == 0f) {
            ChildDisable();
            return;
        }

        // 2次方程式の係数 (0.5 * g * t^2 + v0 * t + y0 - groundY = 0)
        float a = 0.5f * gravity;
        float b = velY;
        float c = startY - groundY;

        // 判別式 (b^2 - 4ac)
        float discriminant = (b * b) - (4 * a * c);

        // ルートの中身がマイナスの場合は地面に到達しない（上に向かって永遠に飛ぶ等）
        if (discriminant < 0) {
            ChildDisable();
            return;
        }

        ChildEnable();

        // 2次方程式の解の公式で時間 t を求める
        float sqrtD = Mathf.Sqrt(discriminant);
        float t1 = (-b + sqrtD) / (2 * a);
        float t2 = (-b - sqrtD) / (2 * a);

        // t1とt2のうち、未来の時間（プラスの値）を採用する
        float timeToGround = Mathf.Max(t1, t2);

        // X座標 = 初期X + (X方向の速度 * 落下までの時間)
        float landingX = startX + (velX * timeToGround);

        transform.position = new Vector3(landingX, groundY, transform.position.z);
    }


    private void ChildDisable()
    {
        // 子オブジェクトをすべて非アクティブにする
        foreach (Transform child in transform) {
            child.gameObject.SetActive(false);
        }
    }

    private void ChildEnable()
    {
        // 子オブジェクトをすべてアクティブにする
        foreach (Transform child in transform) {
            child.gameObject.SetActive(true);
        }
    }
}