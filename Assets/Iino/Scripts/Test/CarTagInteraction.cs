using UnityEngine;
using UnityEngine.AI;

public class CarTagInteraction : MonoBehaviour
{
    [SerializeField]
    private float minForce;

    [SerializeField]
    private float maxForce;


    [SerializeField]
    private GameObject ClashEffect;
    
    private bool wasClashed;

    [SerializeField]
    private bool autoDestroy = true;

    [SerializeField]
    private bool isDropItem;

    [SerializeField]
    private GameObject dropItemPrefab;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Car"))
        {
            if(!wasClashed)
            {
                GetComponent<Renderer>().material.color = new Color(0.15f, 0.15f, 0.15f,0.8f);
                CarPatrol carPatrol = GetComponent<CarPatrol>();
                carPatrol.Invalid();
                CarSpawner.instance.DecreasedCar();

                if (autoDestroy)
                {
                    Destroy(gameObject, 10f);
                }
                wasClashed = true;

                EffectManager.instance.PlayEffect(0, transform.position);
                Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
                Vector3 pushDirection = Random.onUnitSphere;
                float force = Random.Range(minForce, maxForce);
                rb.AddForce(pushDirection * force, ForceMode.Impulse);
                this.gameObject.layer = 7;

                GetComponent<CarGrab>().enabled = false;

                if(isDropItem)
                {
                    DropItem(Random.Range(1,4));
                }
            }
        }
    }

    private void DropItem(int dropNum)
    {
        
        for(int i = 0;i < dropNum;++i)
        {
            var spawnPosition = transform.position + new Vector3(Random.Range(-1f, 1f), 2f, Random.Range(-1f, 1f));
            GameObject item = Instantiate(dropItemPrefab,spawnPosition, Quaternion.identity);
            Rigidbody itemRb = item.GetComponent<Rigidbody>();
            Vector3 randomForce = new Vector3(Random.Range(-1f,1f),2f,Random.Range(-1f,1f)).normalized;
            itemRb.AddForce(randomForce, ForceMode.Impulse);
        }
    }
}
