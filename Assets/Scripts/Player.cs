using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float gravity;
    [SerializeField] private bool isGrounded;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float jumpHeight;
    [SerializeField] private Gamemanager gameManager;
    [SerializeField] private ParticleSystem footsteps;
    

    private Vector3 moveDirection;
    private Vector3 velocity;
    private CharacterController controller;
    private Animator anim;
    private bool generated;

    private void Start() {
        controller = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
    }

    private void Update() {
        if(gameManager.hasStarted == true){
            Move();
        }
        else{
            if(anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") && !generated){
                anim.SetInteger("AnimationIndex", Random.Range(1, 8));
                anim.SetTrigger("RandomAnimation");
                generated = true;
            }
        }
    }
    
    private void Move(){
        isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);

        if(isGrounded && velocity.y < 0){
            velocity.y = -2f;
        }
        // else{
        //     anim.SetFloat("Speed", 0.75f, 0.1f, Time.deltaTime);
        // }
        float moveZ = Input.GetAxis("Vertical");
        moveDirection = new Vector3(0, 0, moveZ);
        moveDirection = transform.TransformDirection(moveDirection);
        
        if(isGrounded){
            if(Input.GetKeyDown(KeyCode.Space)){
                Jump();
            }
            if(moveDirection != Vector3.zero){
                Run();
            }
            else if(moveDirection == Vector3.zero){
                Idle();
            }
            // else if(moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift)){
            //     Walk();
            // }

            moveDirection *= moveSpeed;
        }
        
        controller.Move(moveDirection * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
    
    private void Idle(){
        anim.SetFloat("Speed", 0f, 0.1f, Time.deltaTime);
    }

    private void Run(){
        moveSpeed = runSpeed;
        anim.SetFloat("Speed", 0.5f, 0.1f, Time.deltaTime);
    }

    private void Walk(){
        moveSpeed = walkSpeed;
        anim.SetFloat("Speed", 0.25f, 0.1f, Time.deltaTime);
    }

    private void Jump(){
        if(isGrounded){
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
            anim.SetFloat("Speed", 0.75f, 0.1f, Time.deltaTime);
        } 
    }

    void OnControllerColliderHit(ControllerColliderHit hit){
        if(gameManager.hasStarted && hit.gameObject.CompareTag("Hexagon")){
            StartCoroutine(StartDestroy(hit.gameObject));
        }
    }

    IEnumerator StartDestroy(GameObject hexagon)
    {
        yield return new WaitForSeconds(0.1f);
        var color = hexagon.GetComponent<Renderer>().material;
        color.DOColor(Color.white, 0.05f);
        Destroy(hexagon, 0.7f);
    }
}
