using UnityEngine;

public class BallController : MonoBehaviour
{
    public float forceAmount = 10f; // 吹っ飛ぶ力の大きさ

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("衝突");
        if (collision.gameObject.CompareTag("Player")) // プレイヤーに触れたら
        {
            Debug.Log("プレイヤーと");
            Vector3 direction = (transform.position - collision.transform.position).normalized; // 触れた方向を計算
            Rigidbody rb = GetComponent<Rigidbody>(); // ボールのRigidbodyを取得

            if (rb != null)
            {
                rb.AddForce(direction * forceAmount, ForceMode.Impulse); // 反対方向に力を加える
            }
        }
    }
}
