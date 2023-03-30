using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float moveSpeed;
    public Animator anim;

    private Vector2 moveInput;

    //Steps
    public float stepHeight = 1;
    public LayerMask enviornment;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        



    }

    private void FixedUpdate()
    {
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
        moveInput.Normalize();
        rb.velocity = new Vector3(moveInput.x * moveSpeed, rb.velocity.y, moveInput.y * moveSpeed);

        //Step Up
        Vector3 moveDir = new Vector3(moveInput.x, 0, moveInput.y);
        float castDistance = 0.7f;
        float castDownDisplacement = 0.75f;
        Debug.DrawRay(transform.position + Vector3.down * castDownDisplacement, moveDir.normalized * castDistance);
        if (Physics.Raycast(transform.position + Vector3.down * castDownDisplacement, moveDir.normalized, castDistance, enviornment))
        {
            Debug.Log("hit step");
            Vector3 stepDisplacement = Vector3.up * stepHeight;
            Debug.DrawRay(transform.position + Vector3.down * castDownDisplacement + stepDisplacement, moveDir.normalized * castDistance);
            if (!Physics.Raycast(transform.position + Vector3.down * castDownDisplacement + stepDisplacement, moveDir.normalized, castDistance, enviornment))
            {
                Debug.Log("moving step");
                rb.MovePosition(rb.position + stepDisplacement + (rb.velocity * Time.fixedDeltaTime));
            }
        }

        //Animation
        if (moveInput.magnitude != 0)
        {
            anim.SetFloat("Xinput", moveInput.x);
            anim.SetFloat("Yinput", moveInput.y);
            anim.SetBool("Walking", true);
        }
        else
        {
            anim.SetBool("Walking", false);
        }
    }

    // Update is called once per frame
    void Update()
    {
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
