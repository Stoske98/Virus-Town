using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementPlayer : MonoBehaviour
{
    public Animator anime;
    public Joystick joystick;
    public Rigidbody rb;
    public float playerSpeed = 10;
    public float rotationSpeed = 50;
    public bool jump = false;
    public float jumpForce = 10;
    private float move = 0;
    private float rotate = 0;
    private float napred = 0;
    private float rotiraj = 0;
    private bool seta = false;
    private bool trci = false;
    private float kreni;
    private float okreni;
    // Start is called before the first frame update

    private AudioManager walkSound;
    void Start()
    {
        walkSound = FindObjectOfType<AudioManager>();
        rb.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        /* if (joystick.Horizontal >= .3f)
          {
              rotate = rotationSpeed;
          }else if(joystick.Horizontal <= -.3f)
          {
              rotate = -rotationSpeed;
          }
          else{
              rotate = 0;
          }
          if(joystick.Vertical >= .2f)
          {
              if(trci == false)
              {
                  walkSound.Play("Walk");
                  walkSound.Pitch("Walk", 0.6f);
                  trci = true;
                  seta = false;
              }

              anime.SetBool("Walk", false);

              anime.SetBool("Run", true);
              move = playerSpeed;
          }else if(joystick.Vertical <= -.2f)
          {

              if (seta == false)
              {
                  walkSound.Play("Walk");
                  walkSound.Pitch("Walk", 0.35f);
                  seta = true;
                  trci = false;
              }

              anime.SetBool("Run", false);
              //anime.SetBool("Walk", true);
              move = -playerSpeed+2;
          }else if((joystick.Vertical >= .1f && joystick.Vertical < .2f) )
          {
              if (seta == false)
              {
                  walkSound.Play("Walk");
                  walkSound.Pitch("Walk", 0.35f);
                  seta = true;
                  trci = false;
              }
              anime.SetBool("Walk", true);
              anime.SetBool("Run", false);
              move = playerSpeed - 2;
          }
          else
          {
              trci = false;
              seta = false;

              walkSound.Stop("Walk");
              anime.SetBool("Walk", false);
              anime.SetBool("Run", false);
              move = 0;
          }*/





        kreni = Input.GetAxis("Vertical");
        okreni = Input.GetAxis("Horizontal");

        napred = /*move*/ kreni * Time.deltaTime * playerSpeed;
        rotiraj =/* rotate*/okreni * Time.deltaTime * rotationSpeed;
        /* if(move > playerSpeed - (playerSpeed / 1.3f))
         {


         }
         else
         {
             anime.SetBool("Run", false);
         }*/
        /*if(napred>0)
        {
            anime.SetBool("Run", true);
        }*/
        if (napred > 0)
        {

            anime.SetBool("Run", true);
        }
        else
        {
            anime.SetBool("Run", false);

        }
        if (napred < 0)
        {

            anime.SetBool("Backwards", true);
        }
        else
        {
            anime.SetBool("Backwards", false);

        }
        transform.position += transform.forward * napred;

        transform.Rotate(0, rotiraj, 0);
        /*  if (move == playerSpeed - (playerSpeed / 1.3f))
          {
              Debug.Log("Walk");
          }*/


        //  Debug.Log(playerSpeed / 100 * 75);
    }

    public void Jump()
    {
        if (jump == false)
        {
            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
            jump = true;
        }

    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Ground")
        {
            jump = false;
        }


    }
}
