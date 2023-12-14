using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGrabbable
{
    public GameObject Grabbed();

    public void Release(Vector3 direction, float force);
}
