using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraScript : MonoBehaviour
{
    #region tooltips and parameters
    [SerializeField]
    [Tooltip("プレイヤーの地点")]
    private Transform _targetTransform;
    [SerializeField]
    [Tooltip("カメラの地点")]
    private Transform _cameraTransform;
    [SerializeField]
    [Tooltip("カメラのオフセット")]
    private Vector3 _offset;
    [SerializeField]
    [Tooltip("カメラ速度")]
    private Vector3 _cameraVelocity;
    [SerializeField]
    [Tooltip("カメラのスムーズな動き")]
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
