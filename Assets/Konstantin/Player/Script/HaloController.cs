using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaloController : MonoBehaviour
{
    [SerializeField] public float colorChangeMultiplier = 0.1f;
    [SerializeField] private Material haloMaterial;
    private int currentScore;
    // Start is called before the first frame update
    void Start()
    {
        haloMaterial.SetColor("_Color", new Color(1f, 1f, 0f, 1));
        currentScore = HumanManager.HumanDeathCount;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentScore != HumanManager.HumanDeathCount)
        {
            float colorChange = 1 - currentScore * colorChangeMultiplier;
            if (colorChange > 0)
            {
                haloMaterial.SetColor("_Color", new Color(colorChange, colorChange, 0f, 1f));
               
            }
            else
            {
                haloMaterial.SetColor("_Color", new Color(0f, 0f, 0f, 1f));

            }
            currentScore = HumanManager.HumanDeathCount;
        }
    }
}
