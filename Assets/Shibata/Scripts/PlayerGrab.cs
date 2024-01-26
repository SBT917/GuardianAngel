using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityFx.Outline;
using static UnityEditor.PlayerSettings;

public class PlayerGrab : MonoBehaviour
{
    private PlayerStateMachine stateMachine;
    private IGrabbable grabbable;
    private float followSpeed;
    private float followPosOffset;
    private bool isHit;
    private OutlineBehaviour outline;

    [SerializeField] private Color outlineColor = Color.cyan;
    [SerializeField] private OutlineResources outlineResources;
    [SerializeField] private GameObject aimingUi;
    [SerializeField] private float grabRadius = 1f;
    [SerializeField] private float grabDistance = 1.5f;

    public GameObject GrabbingObject { get; private set; }

    private void Awake()
    {
        transform.parent.TryGetComponent(out stateMachine);
        if(stateMachine != null) followSpeed = stateMachine.MovementSpeed;
    }

    private void Update()
    {
        FollowGrabbingObject();
    }

    
    public void Grab()
    {
        if (GrabbingObject != null) return;
        if (stateMachine.GetState().GetType() != typeof(PlayerMoveState)) return;
        


        if(isHit)
        {
            DisableOutline();
            isHit = false;
            GrabbingObject = grabbable.Grabbed(out followPosOffset);
            aimingUi.gameObject.SetActive(true);
            AudioManager.instance.PlaySE("Grab");
        }
    }

    public void Release(float force)
    {
        if (GrabbingObject == null) return;

        DisableOutline();
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

    private void EnableOutline(GameObject gameObject)
    {
        if (!gameObject.TryGetComponent(out outline))
        {
            outline = gameObject.AddComponent<OutlineBehaviour>();
            outline.OutlineResources = outlineResources;
            outline.OutlineColor = outlineColor;
        }
        else
        {
            outline.enabled = true;
        }
    }

    private void DisableOutline()
    {
        if (outline != null)
        {
            outline.enabled = false;
            outline = null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (stateMachine.GetState().GetType() != typeof(PlayerMoveState)) return;
        if (isHit) return;
        if (GrabbingObject != null) return;

        if (other.TryGetComponent(out grabbable))
        {
            isHit = true;
            EnableOutline(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!isHit) return;
        if (GrabbingObject != null) return;

        if (other.TryGetComponent(out grabbable))
        {
            isHit = false;
            DisableOutline();
        }
    }

}
