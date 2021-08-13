using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayer : MonoBehaviour
{
    public float walk = 0.5f;
    public float run = 1.0f;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //Player Move forward and Animation
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey("w") || Input.GetKey(KeyCode.LeftShift) && Input.GetKey("up"))
        {
            transform.position += transform.forward * run * Time.deltaTime;
            anim.Play("Run");
        }
        else if (Input.GetKey("w") || Input.GetKey("up"))
        {
            transform.position += transform.forward * walk * Time.deltaTime;
            anim.Play("Walk");
        }

        //Player Move backward and Animation
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey("s") || Input.GetKey(KeyCode.LeftShift) && Input.GetKey("down"))
        {
            transform.position -= transform.forward * run * Time.deltaTime;
            anim.Play("Run");
        }
        else if (Input.GetKey("s") || Input.GetKey("down"))
        {
            transform.position -= transform.forward * walk * Time.deltaTime;
            anim.Play("Walk");
        }

        //Player Move right and Animation
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey("d") || Input.GetKey(KeyCode.LeftShift) && Input.GetKey("right"))
        {
            transform.position += transform.right * run * Time.deltaTime;
            anim.Play("Run");
        }
        else if (Input.GetKey("d") || Input.GetKey("right"))
        {
            //transform.Rotate(0, 1f, 0);
            transform.position += transform.right * walk * Time.deltaTime;
            anim.Play("Walk");
        }

        //Player Move left and Animation
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey("a") || Input.GetKey(KeyCode.LeftShift) && Input.GetKey("left"))
        {
            transform.position -= transform.right * run * Time.deltaTime;
            anim.Play("Run");
        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            //transform.Rotate(0, -1f, 0);
            transform.position -= transform.right * walk * Time.deltaTime;
            anim.Play("Walk");
        }

        if (Input.GetMouseButton(0))
        {
            anim.Play("Attack01");
        }
        if (Input.GetMouseButton(1))
        {
            anim.Play("Attack02");
        }
    }
}
