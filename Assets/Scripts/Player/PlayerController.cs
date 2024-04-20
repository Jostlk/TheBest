using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Gravity = 9.8f;
    private float _fallVelocity = 0;
    private CharacterController _characterController;
    public float JumpForce;
    public float Speed;
    private Vector3 _moveVector;
    public Animator animator;
    public AudioSource Jump;
    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void Update()
    {
        //Move
        _moveVector = Vector3.zero;
        var runDirection = 0;
        if (Input.GetKey(KeyCode.W))
        {
            _moveVector += transform.forward;
            runDirection = 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _moveVector += transform.right;
            runDirection = 3;
        }
        if (Input.GetKey(KeyCode.S))
        {
            _moveVector += -transform.forward;
            runDirection = 2;
        }
        if (Input.GetKey(KeyCode.A))
        {
            _moveVector += -transform.right;
            runDirection = 4;
        }
        //Jump
        if (Input.GetKeyDown(KeyCode.Space) && _characterController.isGrounded)
        {
            Jump.Play();
            _fallVelocity = -JumpForce;
        }
        animator.SetInteger("Run direction", runDirection);
    }
    void FixedUpdate()
    {
        //Move
        _characterController.Move(_moveVector * Speed * Time.fixedDeltaTime);
        _fallVelocity += Gravity * Time.fixedDeltaTime;
        //Gravity
        _characterController.Move(_fallVelocity * Time.fixedDeltaTime * Vector3.down);
        if (_characterController.isGrounded)
        {
            _fallVelocity = 0;
        }
    }
}
