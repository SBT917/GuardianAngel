using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorController : MonoBehaviour
{
    private float fallSpeed;
    [SerializeField] GameObject explodeEffect;
    [SerializeField] FallPointMarker fallPointMaker;
    [SerializeField] private LayerMask ingnoreLayer;


    void Awake()
    {

    }

    private void Start()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity, ~ingnoreLayer))
        {
            Vector3 pos = hit.point;
            pos.y += 0.1f;
            var m = Instantiate(fallPointMaker, pos, Quaternion.identity);
            m.ParentMeteor = gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];
        Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Vector3 pos = contact.point;
        EffectManager.instance.PlayEffect(1, pos, rot);
        if(collision.gameObject.tag == "Player")
        {
            PlayerStateMachine stateMachine = collision.gameObject.GetComponent<PlayerStateMachine>();
            stateMachine.SwitchState(new PlayerStunState(stateMachine));
        }
        Destroy(gameObject);
    }

}
