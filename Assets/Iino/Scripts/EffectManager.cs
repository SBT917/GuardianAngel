using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EffectManager : MonoBehaviour
{
    public static EffectManager instance;

    public List<GameObject> effects;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void PlayEffect(int effectID,Vector3 position)
    {
        Instantiate(effects[effectID], position, effects[0].transform.rotation);
    }

    public void PlayEffect(int effectID, Vector3 position, Quaternion rot)
    {
        Instantiate(effects[effectID], position, rot);
    }
}
