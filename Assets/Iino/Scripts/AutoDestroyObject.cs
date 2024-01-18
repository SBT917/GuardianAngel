using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroyObject : MonoBehaviour
{
    public int DestroySeconds;
    void Start()
    {
        Destroy(gameObject,DestroySeconds);
    }

}
