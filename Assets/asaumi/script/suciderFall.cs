using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class suciderFall : MonoBehaviour
{
    public float raycastDistance = 1f;  // Raycastの長さ
    public LayerMask groundLayer;       // 地面として判定するレイヤー
    private Animator animator;

    void Start()
    {
        // Animatorコンポーネントを取得
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Rayをキャラクターの下方向に飛ばす
        Ray ray = new Ray(transform.position, Vector3.down);
        RaycastHit hit;

        // Raycastで地面との接触判定を行う
        if (Physics.Raycast(ray, out hit, raycastDistance, groundLayer))
        {
            // 地面に接触している場合
            animator.Play("run");  // "run"アニメーションを再生
        }
        else
        {
            // 地面に接触していない場合
            animator.Play("fall");  // "fall"アニメーションを再生
        }
    }
}
