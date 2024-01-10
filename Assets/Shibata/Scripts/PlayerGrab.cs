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
        targetPos = transform.position + Vector3.up * followPosOffset;

        Vector3 moveDirection = (targetPos - GrabbingObject.transform.position).normalized;
        if (Vector3.Distance(targetPos, GrabbingObject.transform.position) > 0.5f)
        {
            GrabbingObject.transform.position += moveDirection * followSpeed * Time.deltaTime;

        }
    }

}
