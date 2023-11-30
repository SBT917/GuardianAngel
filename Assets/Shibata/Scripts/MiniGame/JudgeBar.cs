using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgeBar : MonoBehaviour
{
    private float moveSpeed = 100;
    private bool isMoving = false;

    [SerializeField] private AudioSource audioSource;

    void Awake()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            audioSource.PlayOneShot(audioSource.clip);
            isMoving = true;
        }

        if(isMoving == false) return;
        transform.position += new Vector3(moveSpeed * Time.deltaTime, 0, 0);
    }
}
