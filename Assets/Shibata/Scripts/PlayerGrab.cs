using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrab : MonoBehaviour
{
    private PlayerStateMachine stateMachine;
    private IGrabbable grabbable;
    private float followSpeed;
    private float followPosOffset;
    [SerializeField] private GameObject aimingUi;

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
        Vector3 direction = transform.TransformDirection(Vector3.forward);
        if (Physics.BoxCast(transform.position, Vector3.one, direction, out hit, Quaternion.identity, 1f))
        {
            if (hit.transform.TryGetComponent(out grabbable))
            {
                GrabbingObject = grabbable.Grabbed(out followPosOffset);
                aimingUi.gameObject.SetActive(true);
            }
        }
    }

    public void Release(float force)
    {
        if (GrabbingObject == null) return;

        grabbable.Release(stateMachine.MainCamera.transform.forward, force);
        aimingUi.gameObject.SetActive(false);
        GrabbingObject = null;
    }

    private void FollowGrabbingObject()
    {
        if (GrabbingObject == null) return;

        Vector3 targetPos;
        if (stateMachine.GetState().GetType().Equals(typeof(PlayerFlyState)))
        {
            targetPos = transform.position + transform.up;
            //targetPos.y = transform.position.y - 2;
        }
        else
        {
            targetPos = transform.position + transform.forward * followPosOffset;
            targetPos.y += 1;
        }


        Vector3 moveDirection = (targetPos - GrabbingObject.transform.position).normalized;
        if (Vector3.Distance(targetPos, GrabbingObject.transform.position) > 2)
        {
            GrabbingObject.transform.position += moveDirection * followSpeed * Time.deltaTime;

        }
    }

}
