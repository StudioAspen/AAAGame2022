using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float moveSpeed;
    public Animator anim;

    private Vector2 moveInput;
    public VectorValue startingPosition;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
        moveInput.Normalize();
        rb.velocity = new Vector3(moveInput.x * moveSpeed, rb.velocity.y, moveInput.y * moveSpeed);

        

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
}
