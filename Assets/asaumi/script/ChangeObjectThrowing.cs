using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChangeObjectThrowing : MonoBehaviour
{
    [SerializeField]
    GameObject ChangeDestination;

    [HideInInspector]
    public bool IsThrowing;

    bool alredyGeneretedClone;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Car"))
        {
            CreateDeadClone();
        }

        if(IsThrowing)
        {
            CreateDeadClone();
        }
    }

    public void CreateDeadClone()
    {
        if (!alredyGeneretedClone)
        {
            Instantiate(ChangeDestination, transform.position, transform.rotation);
            alredyGeneretedClone = true;
        }
        Destroy(gameObject);
    }
}
