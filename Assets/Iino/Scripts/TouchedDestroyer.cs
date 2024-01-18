using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TouchedDestroyer : MonoBehaviour
{


    private Vector3 spawnPoint = new Vector3(-40, 40, -40);

    private void OnTriggerEnter(Collider other)
    {
        var objTag = other.gameObject.tag;
        switch(objTag)
        {
            case "Car":
                Destroy(other.gameObject);
                break;
            case "Medical":
                Destroy(other.gameObject);
                break;
            case "Player":
                //Debug.Log("player entered water");
                other.GetComponent<PlayerGrab>().Release(0);
                other.GetComponent<Transform>().position = spawnPoint;
                break;
            default:
                break;
        }

    }

}
