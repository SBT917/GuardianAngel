using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerScript : MonoBehaviour
{
    #region tooltips and parameters
    [SerializeField]
    [Tooltip("プレイヤーの立場")]
    private Vector3 _playerPosition;
    [SerializeField]
    [Tooltip("跳躍力")]
    private float _playerJumpForce;
    [SerializeField]
    [Tooltip("歩行速度")]
    private float _playerWalkSpeed;
    //[SerializeField]
    //components
    private Collider _playerCollider;
    private Rigidbody _playerRigidbody;
    private Animator _playerAnimator;
    //private PlayerInput _playerInput;
    //states
    [SerializeField]
    [Tooltip("jumping?")]
    private bool _isJumping;
    [SerializeField]
    [Tooltip("jumping?")]
    private bool _onGround;
    [SerializeField]
    [Tooltip("jumping?")]
    private bool _isFalling;


    #endregion
    void Awake()
    {
        this._InitVariables();
        this._GetComponents();
    }
    void Start()
    {
        //this._playerInput.Enable();    
    }
    void Update()
    {

        if(Input.GetAxisRaw("Jump")!=0)
        {
            _Jump();
        }
    }
    private void _Jump()
    {
        if(this._onGround)
        {
            this._playerRigidbody.velocity = new Vector3(0f, this._playerJumpForce, 0f);
            this._onGround = false;
            this._isJumping = true;
            this._isFalling = false;
        }
    }

    private void _InitVariables()
    {
        this._playerPosition = this.transform.position;
        this._playerWalkSpeed = 10.0f;
        this._playerJumpForce = 7f;
        this._isJumping = false;
        this._onGround = true;
        this._isFalling = false;
    }
    private void _GetComponents()
    {
        this._playerCollider ??= GetComponent<Collider>();
        //this._playerInput = new PlayerInput();
        this._playerRigidbody ??= GetComponent<Rigidbody>();
        if(_playerRigidbody == null ) 
        {
            Debug.Log("RigidBody is null, fix that!!!");
        }
        this._playerAnimator ??= GetComponent<Animator>();
        if(_playerAnimator == null) 
        { 
            this._playerAnimator ??= gameObject.GetComponentInChildren<Animator>();
        }
    }
    // Update is called once per frame

}
