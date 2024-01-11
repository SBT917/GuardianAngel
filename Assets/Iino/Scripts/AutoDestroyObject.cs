using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroyObject : MonoBehaviour
{
    public int DestroyFrame;
    void Start()
    {
        Destroy(gameObject,DestroyFrame);
    }

}
