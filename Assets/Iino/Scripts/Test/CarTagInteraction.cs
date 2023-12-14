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
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Car"))
        {
            if(!wasClashed)
            {
                CarPatrol carPatrol = GetComponent<CarPatrol>();
                carPatrol.Invalid();
                CarSpawner.instance.DecreasedCar();

                if (autoDestroy)
                {
                    Destroy(gameObject, 10f);
                }
                wasClashed = true;
            }
            
            Instantiate(ClashEffect, transform.position, Quaternion.identity);
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 pushDirection = Random.onUnitSphere;
            float force = Random.Range(minForce, maxForce);
            rb.AddForce(pushDirection * force, ForceMode.Impulse);

        }
    }
}
