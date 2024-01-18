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

    [SerializeField]
    private GameObject ball;

    [SerializeField]
    private GameObject SpecialBall;

    [SerializeField]
    private GameObject BonusItem;

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.CompareTag("Ball") && !alreadyGoal)
        {
            alreadyGoal = true;
            EffectManager.instance.PlayEffect(6,transform.position);
            StartCoroutine(BallInitPos(collision.gameObject));
            score++;
            var spawnPosition = ballInitPosition.position + new Vector3(0, 2, 0);
            for (int i = 0; i < score; ++i)
            {
                GameObject item = Instantiate(BonusItem, spawnPosition, Quaternion.identity);
                Rigidbody itemRb = item.GetComponent<Rigidbody>();
                Vector3 randomForce = new Vector3(Random.Range(-1f, 1f), 2f, Random.Range(-1f, 1f)).normalized;
                itemRb.AddForce(randomForce, ForceMode.Impulse);
            }
        }
    }

    private IEnumerator BallInitPos(GameObject ball)
    {
        yield return new WaitForSeconds(3);
        ball.transform.position = ballInitPosition.position;
        ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
          alreadyGoal = false;
    }
}
