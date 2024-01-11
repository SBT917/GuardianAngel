using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaloController : MonoBehaviour
{
    [SerializeField]
    private Material haloMaterial;

    private int currentScore;
    // Start is called before the first frame update
    void Start()
    {
        haloMaterial.SetColor("_Color", new Color(0f, 255f, 0f, 255f));
        currentScore = HumanManager.HumanDeathCount;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentScore!=HumanManager.HumanDeathCount) 
        { 
            haloMaterial.SetColor("_Color", new Color(0f,255-currentScore*10.0f,0f,255f)); 
            currentScore = HumanManager.HumanDeathCount;
        }
    }
}
