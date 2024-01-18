using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevivalItem : MonoBehaviour
{
    [SerializeField]
    bool IsDestroyAfterRevive;

    public LayerMask targetLayer;
    public float detectionRadius = 5f;

    [HideInInspector]
    public bool alreadyThrowing;

    [SerializeField]
    ItemGrab itemGrab;

    private void Start()
    {
        itemGrab = GetComponent<ItemGrab>();
        itemGrab.OnItemThrown += OnThrow;
    }

    private void OnCollisionEnter(Collision collision)
    {
        /*if (collision.gameObject.CompareTag("death"))
        {
            collision.gameObject.transform.root.gameObject.GetComponent<HumanRevival>().Revive();
            if (IsDestroyAfterRevive) { Destroy(gameObject); }
        }*/

        if (alreadyThrowing)
        {

            Collider[] colliders = Physics.OverlapSphere(transform.position, detectionRadius, targetLayer);


            foreach (Collider col in colliders)
            {
                if (col.CompareTag("death"))
                {
                    col.gameObject.transform.root.gameObject.GetComponent<HumanRevival>().Revive();
                }
            }
            if (IsDestroyAfterRevive) { Destroy(gameObject); }
        }
    }

    /*private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }*/

    private void OnThrow()
    {
        alreadyThrowing = true;
    }
}
