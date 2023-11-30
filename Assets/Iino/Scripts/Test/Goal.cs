using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField]
    Transform ballInitPosition;

    public int score;
    private bool alreadyGoal;


    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.CompareTag("Ball") && !alreadyGoal)
        {
            alreadyGoal = true;
            StartCoroutine(BallInitPos(collision.gameObject));
            score++;
        }
    }

    private IEnumerator BallInitPos(GameObject ball)
    {
        yield return new WaitForSeconds(3);
        ball.transform.position = ballInitPosition.position;
        alreadyGoal = false;
        ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}
