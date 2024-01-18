using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbulanceRevive : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("death"))
        {
            collision.gameObject.transform.root.gameObject.GetComponent<HumanRevival>().Revive();
        }
    }
}
