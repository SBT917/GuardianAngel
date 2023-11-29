using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGrabbable
{
    void Grabbed(Transform transform);

    void Release(Transform transform);
}
