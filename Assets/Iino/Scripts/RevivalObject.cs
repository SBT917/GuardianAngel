using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevivalObject : MonoBehaviour
{
    [SerializeField]
    bool IsDestroyAfterRevive;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("death"))
        {
            collision.gameObject.transform.root.gameObject.GetComponent<HumanRevival>().Revive();
            if (IsDestroyAfterRevive) { Destroy(gameObject); }
        }
    }


}
