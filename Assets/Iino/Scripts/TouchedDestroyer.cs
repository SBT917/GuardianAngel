using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchedDestroyer : MonoBehaviour
{
    [SerializeField]
    string[] DestroyTags;

    private void OnTriggerEnter(Collider other)
    {
        var objTag = other.gameObject.tag;
        if(ChackTag(objTag))
        {
            Destroy(other.gameObject);
        }
    }

    private bool ChackTag(string objTag)
    {
        for (int i = 0; i < DestroyTags.Length; i++)
        {
            objTag = DestroyTags[i];
            return true;
        }

        return false;
    }
}
