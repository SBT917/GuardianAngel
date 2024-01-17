using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeGauge : MonoBehaviour
{
    private Image image;

    void Start()
    {
        TryGetComponent(out image);
        TimeManager.instance.onUpdateTimeCount += UpdateTimeGauge;

        //TryGetComponent(out RectTransform rect);
        //rect.position = new Vector3(rect.position.x, -50, rect.position.z);
    }

    private void UpdateTimeGauge(float time)
    {
        image.fillAmount = time / TimeManager.instance.MaxTime;
    }

}
