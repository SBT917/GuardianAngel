using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraScript : MonoBehaviour
{
    #region tooltips and parameters
    [SerializeField]
    [Tooltip("�v���C���[�̒n�_")]
    private Transform _targetTransform;
    [SerializeField]
    [Tooltip("�J�����̒n�_")]
    private Transform _cameraTransform;
    [SerializeField]
    [Tooltip("�J�����̃I�t�Z�b�g")]
    private Vector3 _offset;
    [SerializeField]
    [Tooltip("�J�������x")]
    private Vector3 _cameraVelocity;
    [SerializeField]
    [Tooltip("�J�����̃X���[�Y�ȓ���")]
    private float _cameraSmoothness;
    #endregion
    void Awake()
    {
        this._cameraSmoothness = 0.7f;
    }
    void Start()
    {
        this._offset = _cameraTransform.position - _targetTransform.position;
    }
    void LateUpdate()
    {
        //update position
        Vector3 targetPosition = this._targetTransform.position + this._offset;
        this._cameraTransform.position = Vector3.SmoothDamp(transform.position, targetPosition, 
                                                           ref this._cameraVelocity, this._cameraSmoothness);
        //update rotation
        this.transform.LookAt(this._targetTransform);
    }

}
