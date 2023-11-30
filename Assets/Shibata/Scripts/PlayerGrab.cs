using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerGrab : MonoBehaviour
{
    private PlayerStateMachine stateMachine;
    private IGrabbable grabbable;
    [SerializeField]
    private float followSpeed;

    public GameObject GrabbingObject { get; private set; }

    private void Awake()
    {
        TryGetComponent(out stateMachine);
        if(stateMachine != null) followSpeed = stateMachine.MovementSpeed;
    }

    private void Update()
    {
        FollowGrabbingObject();
    }

    public void Grab()
    {
        if (GrabbingObject != null) return;

        RaycastHit hit;
        Vector3 direction = stateMachine.GetState().GetType() == typeof(PlayerFlyState) ? 
                            transform.TransformDirection(Vector3.down) : transform.TransformDirection(Vector3.forward);
        Vector3 pos = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
        Debug.DrawRay(pos, direction * 2.0f, Color.red);
        if (Physics.Raycast(pos, direction, out hit, 2.0f))
        {
            if (hit.transform.TryGetComponent(out grabbable))
            {
                GrabbingObject = grabbable.Grabbed();
            }
        }
    }

    public void Release()
    {
        if (GrabbingObject == null) return;

        grabbable.Release(-transform.up, 10);
        GrabbingObject = null;
    }

    private void FollowGrabbingObject()
    {
        if (GrabbingObject != null)
        {
            Vector3 targetPos;
            if (stateMachine.GetState().GetType().Equals(typeof(PlayerFlyState))) 
            {
                targetPos = transform.position + transform.up;
                //targetPos.y = transform.position.y - 2;
            }
            else
            {
                targetPos = transform.position + transform.forward * 3;
                targetPos.y += 1;
            }
             
            
            Vector3 moveDirection = (targetPos - GrabbingObject.transform.position).normalized;
            if(Vector3.Distance(targetPos, GrabbingObject.transform.position) > 2)
            {
                GrabbingObject.transform.position += moveDirection * followSpeed * Time.deltaTime;
                
            }
        }
    }
}
