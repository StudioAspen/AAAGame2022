using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterMovement : MonoBehaviour
{
    public Transform camera;

    public Rigidbody rb;
    public float moveSpeed;
    
    public Animator anim;

    private Vector2 moveInput;
    public VectorValue startingPosition;
    public string startingScene;

    //Steps
    public float stepHeight = 1;
    public LayerMask enviornment;

    public GameObject stepRayLower;
  
    void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    private void FixedUpdate()
    {
        Move();
        Step();
        MoveAnimation();
    }

    void Move() 
    {
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");

        Vector3 forward = camera.forward;
        Vector3 right = camera.right;
        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        Vector3 desiredDirection = forward * moveInput.y + right * moveInput.x;

        if (desiredDirection.magnitude > 0)
        {
            transform.eulerAngles = camera.eulerAngles;
        }

        Vector3 movement = desiredDirection * moveSpeed;
        rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);
    }

    void Step() {
        //Step Up
        Vector3 moveDir = new Vector3(moveInput.x, 0, moveInput.y);
        float castDistance = 0.7f;
        float castDownDisplacement = 0.75f;
        Debug.DrawRay(stepRayLower.transform.position + Vector3.down * castDownDisplacement, moveDir.normalized * castDistance);
        if (Physics.Raycast(stepRayLower.transform.position + Vector3.down * castDownDisplacement, moveDir.normalized, castDistance, enviornment))
        {
            Debug.Log("hit step");
            Vector3 stepDisplacement = (Vector3.up * stepHeight);
            Debug.DrawRay(transform.position + Vector3.down * castDownDisplacement + stepDisplacement, moveDir.normalized * castDistance);
            if (!Physics.Raycast(transform.position + Vector3.down * castDownDisplacement + stepDisplacement, moveDir.normalized, castDistance, enviornment))
            {
                Debug.Log("moving step");
                rb.MovePosition(rb.position + stepDisplacement + (rb.velocity * Time.fixedDeltaTime));
            }
        }
    }
  
    void MoveAnimation() {
        if (moveInput.magnitude != 0)
        {
            anim.SetFloat("Xinput", moveInput.normalized.x);
            anim.SetFloat("Yinput", moveInput.normalized.y);
            anim.SetBool("Walking", true);
        }
        else
        {
            anim.SetBool("Walking", false);
        }
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.E))
        {
            //returns list of colliders
            Collider[] colliders = Physics.OverlapSphere(transform.position, radius: 1);
            for(int i = 0; i < colliders.Length; i++)
            {
                NPC npc;
                if(colliders[i].gameObject.TryGetComponent<NPC>(out npc))
                {
                    npc.Interact();
                    break;
                }
            }  
        }
    }

    public void DevControls()
    {

    }
}
