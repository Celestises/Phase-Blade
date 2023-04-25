using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameObject a;
    private NoteManager n;
    private Rigidbody2D rb;
    [SerializeField][Range(0,100)] private int moveSpeed;
    [SerializeField][Range(0f,100f)] private float accelerationX;
    [SerializeField][Range(0f,5f)] private float jumpHeight;
    [SerializeField][Range(0f,5f)] private float brakes;
    private bool jumping;
    [SerializeField] private float fallSpeed;
    [SerializeField] private float prevVel;
    private float currentVel;


    // Start is called before the first frame update
    void Start()
    {
    n = GameObject.Find("NoteManager").GetComponent<NoteManager>();
    rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (n.musicSection){
                if (Input.GetKeyDown(KeyCode.S))
        {
            Destroy(a);
            Debug.Log("hi");

        }
        }
        else{
        prevVel = currentVel;
       currentVel = rb.velocity.x;
        if (Input.GetKey(KeyCode.A))
        {
            if (rb.velocity.x > 0f)
            {
                rb.velocity += new Vector2(-moveSpeed * accelerationX * Time.deltaTime*brakes,0);
            }
            else rb.velocity += Mathf.Abs(rb.velocity.x) < moveSpeed ? new Vector2(-moveSpeed * accelerationX * Time.deltaTime,0) : Vector2.zero;
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (rb.velocity.x < 0f)
            {
                rb.velocity += new Vector2(moveSpeed * accelerationX * Time.deltaTime*brakes,0);
            }
            rb.velocity += Mathf.Abs(rb.velocity.x) < moveSpeed ? new Vector2(moveSpeed * accelerationX * Time.deltaTime,0) : Vector2.zero;
        }
        if (Input.GetKey(KeyCode.W) && !jumping)
        {
            rb.velocity += new Vector2(0,Mathf.Sqrt(-2f  * rb.gravityScale * jumpHeight * Physics2D.gravity.y));
            jumping = true;

    

            
        }
        if (jumping && rb.velocity.y < 0)
        {
            rb.velocity -= new Vector2(0, fallSpeed * Time.deltaTime);
        }
        

    }
    }
    void OnTriggerStay2D(Collider2D c)
    {
        if ( !a && c.gameObject.tag == "Note")
        {
        a = c.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if (n.musicSection) a = null;
    }
    private void OnCollisionEnter2D(Collision2D other) 
    {
    if (other.gameObject.tag == "Platform" && !n.musicSection)
    {
        jumping = false;
        rb.velocity = new Vector2(prevVel,0);
    }
    }
    private void OnCollisionExit2D(Collision2D c)
    {
    if (c.gameObject.tag == "Platform" && !n.musicSection)
    {
        jumping = true;
    }
    }
}
