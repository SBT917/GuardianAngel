using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGrabbable
{
    GameObject Grabbed();

    void Release(Vector3 direction, float force);
}
