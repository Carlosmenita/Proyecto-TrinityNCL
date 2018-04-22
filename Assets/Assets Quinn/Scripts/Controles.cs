using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controles : MonoBehaviour {
    public float speed;
    public bool grounded;
    public float jumpPower;
    public bool saltar;

    private Rigidbody2D rb2d;
    private Animator anim;
    private bool jump;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
	}
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Piso")
        {
            grounded = true;
        }
         
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Piso")
        {
            grounded = false;
        }
        
    }
    // Update is called once per frame
    void Update () {
        anim.SetFloat("speed", Mathf.Abs(speed));
        anim.SetBool("grounded", grounded);

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            saltar = true;
            jump = true;
          
        }
        anim.SetBool("Saltar", saltar);
        saltar = false;

    }

    private void FixedUpdate()
    {
        speed = 3f;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        }
        else
        {
            speed = 0f;
        }

        if (jump)
        {
            rb2d.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            jump = false;
            
        }

    }
}
