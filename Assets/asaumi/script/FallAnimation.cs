using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FallAnimation : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rb;
    private float distance;
    bool falling;
    public GameObject boyPrefab; // ボーイPrefabをInspectorからアタッチする
    bool check;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        distance = 3.0f;
        falling = false;
        check = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rayposition = transform.position + new Vector3(0.0f, 0.0f, 0.0f);
        Ray ray = new Ray(rayposition, Vector3.down);
        bool isGround = Physics.Raycast(ray, distance);
        Debug.DrawRay(rayposition, Vector3.down * distance, Color.yellow);
        Debug.Log(isGround);
        if (isGround)
        {
            animator.SetBool("Walk", true);

        }
        else if (!isGround)
        {
            falling = true;
            animator.SetBool("Walk", false);
        }
    }
    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
       
        if (check == false&&falling)
        {
            Instantiate(boyPrefab, transform.position, Quaternion.identity);
            check = true;
            animator.enabled = false;
            this.enabled = false; 
            Destroy(gameObject);
        }
    }
}

