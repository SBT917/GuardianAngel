using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHumanCount : MonoBehaviour
{
    [SerializeField]
    Text humanCountText;

    [SerializeField]
    Text humanDeathCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        humanCountText.text = "������:" + HumanManager.instance.HumanCount.ToString();
        humanDeathCount.text = "����:" + HumanManager.HumanDeathCount.ToString();
    }
}
