using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearanceScaffold : MonoBehaviour
{
    private bool isTouch;
    private float touchCount;

    [SerializeField]
    private float appearanceTime;

    private bool alreadyAppearance;

    [SerializeField]
    Animator scaffoldAnimator;

    private void Update()
    {
        if(!alreadyAppearance && isTouch)
        {
            touchCount += Time.deltaTime;
            if (touchCount >= appearanceTime)
            {
                alreadyAppearance = true;
                scaffoldAnimator.Play("AppearanceScaffold");
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !alreadyAppearance)
        {
            isTouch = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !alreadyAppearance)
        {
            touchCount = 0;
            isTouch = false;
        }
    }

}
