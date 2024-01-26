using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanRevival : MonoBehaviour
{
    [SerializeField]
    GameObject aliveHuman;

    [SerializeField]
    float initYpos;

    private bool alreadyRevived;
    // Start is called before the first frame update

    private void Start()
    {
        initYpos = transform.position.y;
    }

    public void Revive()
    {
        EffectManager.instance.PlayEffect(4, new Vector3(transform.position.x, initYpos + 2, transform.position.z));
        AudioManager.instance.PlaySE("Yatta", new Vector3(transform.position.x, initYpos + 2));
        if (alreadyRevived) return;
        alreadyRevived = true;
        ++HumanManager.instance.HumanCount;
        --HumanManager.HumanDeathCount;
        Instantiate(aliveHuman, new Vector3(transform.position.x, initYpos, transform.position.z), Quaternion.identity);
        //obj.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y + 2, obj.transform.position.z);
        
        Destroy(gameObject);
    }

    
}
