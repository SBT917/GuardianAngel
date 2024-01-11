using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallPointMarker : MonoBehaviour
{
    public GameObject ParentMeteor { get; set; }

    private SpriteRenderer spriteRenderer;
    private float defaultDistance;
    private float distance;
    private Color burnedColor;

    [SerializeField] private Sprite burnMarker;
    [SerializeField] private Color endColor;

    // Start is called before the first frame update
    void Awake()
    {
        TryGetComponent(out spriteRenderer); 
    }

    private void Start()
    {
        distance = Vector3.Distance(gameObject.transform.position, ParentMeteor.transform.position);
        defaultDistance = distance;
        endColor.a = 0;
        burnedColor = Color.white;
        transform.eulerAngles = new Vector3(-90, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (distance >= 10)
        {
            if (ParentMeteor == null) { Destroy(gameObject); return; }
            distance = Vector3.Distance(gameObject.transform.position, ParentMeteor.transform.position);
            endColor.a = 1 - distance / defaultDistance;
            spriteRenderer.color = endColor;
            return;
        }

        spriteRenderer.sprite = burnMarker;
        transform.localScale = new Vector3(10, 10, 10);
        burnedColor.a -= Time.deltaTime * 0.25f;
        spriteRenderer.color = burnedColor;

        if(burnedColor.a < 0) { Destroy(gameObject); }
    }
}
