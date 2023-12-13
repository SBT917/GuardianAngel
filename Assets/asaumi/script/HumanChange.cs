using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanChange : MonoBehaviour
{
    public GameObject boyPrefab; // ボーイPrefabをInspectorからアタッチする
    bool check = false;

    void OnCollisionEnter(Collision collision)
    {
        // 衝突が発生したときの処理
        // 衝突したオブジェクトを消滅させる
        Destroy(gameObject);

        // 新しいPrefabを同じ座標に生成する
        if (check == false)
        {
            Instantiate(boyPrefab, collision.contacts[0].point, Quaternion.identity);
            check = true;
        }

    }
}
