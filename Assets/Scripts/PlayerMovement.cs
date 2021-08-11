using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody rb;

    public float forwardForce = 2000f;
    public float sidewaysForceJump = 500f;
    public float sidewaysForceNoJump = 500f;
    public float detachmentForce = 5000f;
    public float jupmForce = 5000f;

    private bool jumps;
    private float yPosition;
    //public GameObject obj;
    //Mods moods = new Mods();

    //public GameObject mods;
    //private Mods modsScript;

  

    public void setJumps(bool jumps){
        this.jumps = jumps;
    }
    


    void Start()
    {
        GameObject go = GameObject.Find("Player");
        Mods mods = go.GetComponent<Mods>();
        jumps = mods.getJumps();
        yPosition = rb.position.y;
        Debug.Log("START POSITION: " + yPosition);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(jumps);
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        if (Input.GetKey("d"))
        {
            if(jumps) rb.AddForce(sidewaysForceJump * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            else rb.MovePosition(transform.position + Vector3.right * sidewaysForceNoJump * Time.deltaTime);
        }

        if (Input.GetKey("a"))
        {
            if (jumps) rb.AddForce(-sidewaysForceJump * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            else rb.MovePosition(transform.position + Vector3.left * sidewaysForceNoJump * Time.deltaTime);
        }

        if (Input.GetKey("w"))
        {
            rb.AddForce(0, 0, sidewaysForceJump * Time.deltaTime);
        }

        if (Input.GetKey("s"))
        {
            rb.AddForce(0, 0, -sidewaysForceJump * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.Space) && rb.transform.position.y < 2.1 && jumps)
        {
            rb.AddForce(0, jupmForce * Time.deltaTime, 0);
        }

        if (rb.position.y < yPosition)
        {
            Debug.Log("DOWN: " + rb.position.y);
            FindObjectOfType<GameManager>().EndGame();
            enabled = false;
            FindObjectOfType<Score>().scoreStoper();
        }
    }

    public void detachment()
    {
        rb.AddForce(detachmentForce * Time.deltaTime, detachmentForce * Time.deltaTime, 0);
        enabled = false;
    }
}
