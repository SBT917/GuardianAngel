using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PliceCarLight : MonoBehaviour
{
    [SerializeField]
    private Light redLight;
    [SerializeField]
    private Light blueLight;

    [SerializeField]
    private float interval;

    private void Start()
    {
        StartCoroutine(SwitchLights());   
    }

    IEnumerator SwitchLights()
    {
        while(true)
        {
            redLight.enabled = !redLight.enabled;
            blueLight.enabled = !blueLight.enabled;

            yield return new WaitForSeconds(interval);
        }
    }

}
