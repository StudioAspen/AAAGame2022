using UnityEngine;


public class NPCFollow : MonoBehaviour
{
    private Transform target;

    public float speed;
    private float dist;
    private Vector3 direction;
    public float boundary;

    public Animator anim;
    public Animator playerAnim;
    public bool playerMoving;
    public float dirX;
    public float dirY;
    private bool moving;



    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        dist = Vector3.Distance(target.position, transform.position);
        direction = transform.position - target.position;
        playerMoving = playerAnim.GetBool("Walking");
        dirX = playerAnim.GetFloat("Xinput");
        dirY = playerAnim.GetFloat("Yinput");
        if (dist > boundary)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }

        if (this.GetComponent<Rigidbody>().velocity.magnitude > 0.01)
        {
            moving = true;
        }
        if (this.GetComponent<Rigidbody>().velocity.magnitude <= 0.01)
        {
            moving = false;
        }

        if (playerMoving == true)
        {
            anim.SetFloat("X", dirX);
            anim.SetFloat("Y", dirY);
            anim.SetBool("Walking", true);
        }


        else
        {
            anim.SetBool("Walking", false);
        }


    }
}
