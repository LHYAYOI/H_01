using UnityEngine;

public class FrogEnemyScript : EnemyBase
{
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float jumpInterval = 2f; // ジャンプの間隔
    [SerializeField] private float rayDistance = 0.1f; // 足元からのRayの長さ
    [SerializeField] private LayerMask groundLayer;   // 地面レイヤーを設定（推奨）

    private Rigidbody2D rb;
    private float jumpTimer;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpTimer = jumpInterval;
    }

    void Update()
    {
        //地面判定 (コライダーの底面から少し下へRayを飛ばす)
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1.1f, groundLayer);

        if (hit.collider != null)
        {
            if (!isGrounded) // 空中から着地した瞬間
            {
                isGrounded = true;
                rb.linearVelocity = Vector2.zero; // 動きを止める
                rb.gravityScale = 0;              // 滑り落ち防止
            }
        }
        else
        {
            isGrounded = false;
        }

        if (isGrounded)
        {
            jumpTimer -= Time.deltaTime;

            //ジャンプ実行
            if (jumpTimer <= 0)
            {
                Jump();
            }
        }

        //範囲外言ったら死ぬ

        if (transform.position.x < -11 || transform.position.x > 11) 
        {
            Destroy(this.gameObject);
        }
    }

    void Jump()
    {
        rb.gravityScale = 1; // 重力を戻す

        float xDir = -m_moveVector.x;
        Vector2 force = new Vector2(xDir, 1f) * jumpForce;

        rb.AddForce(force, ForceMode2D.Impulse);

        // タイマーをリセット
        jumpTimer = jumpInterval;
    }
}
