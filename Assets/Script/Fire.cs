using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fire : MonoBehaviour
{
    public Animator anime;
    public Text text;
    public float municijaToletPapir = 0;
    public Rigidbody ToletPapir;
   // public Rigidbody Rolna;
    public Rigidbody rolnica;
    public Transform posRolna;
    public float speedPower = 100;
    public float rolnaSpeed = 10;
    public static int num = 0;
    public float FireRate = 5;
    private float fireTimer =0.3f;
  

    public GameObject rolna;
    public GameObject toletPapir;

    private AudioManager soundFire;

    private GameObject pointSystemUI;
    private Text score;
    public static int scoreSystem = 0;


    private void Start()
    {
        text.text = "x" + municijaToletPapir.ToString();
        soundFire = FindObjectOfType<AudioManager>();
        rolna.SetActive(true);
        toletPapir.SetActive(false);

        pointSystemUI = GameObject.Find("PointSystem");
        score = pointSystemUI.GetComponent<Text>();
        score.text = scoreSystem.ToString();
       // scoreSystem = PlayerPrefs.GetInt("HighScore", 0);

    }
    public void Update()
    {
       
        fireTimer += Time.deltaTime;
        // Debug.Log(fireTimer);
        if (municijaToletPapir == 0 && rolna.activeSelf == false && toletPapir.activeSelf == true)
        {
            num = 0;
            rolna.SetActive(true);
            toletPapir.SetActive(false);
            return;
        }
        if (num == 0 && rolna.activeSelf == false)
        {
            rolna.SetActive(true);
            toletPapir.SetActive(false);
            return;
        }
        else if (num == 1 && toletPapir.activeSelf == false)
        {
            rolna.SetActive(false);
            toletPapir.SetActive(true);
            return;
        }

    }


    public void Pucaj()
    {
       
       
        if (fireTimer < FireRate) return;
            {
                anime.SetBool("Fire", true);
                soundFire.Play("Whip");
                if (municijaToletPapir <= 0)
                    {
                        num = 0;
                        
                    }
                StartCoroutine(Delay());
           
            }
       
    }

    IEnumerator Delay()
    {
        fireTimer = 0.0f;
        yield return new WaitForSeconds(0.25f);
        if (num == 0)
        {
            Rigidbody clone1;
            clone1 = Instantiate(rolnica, posRolna.position, posRolna.rotation);
            clone1.velocity = posRolna.forward * speedPower;
           
            
           

        }
        if (num == 1)
        {

            Rigidbody clone1;
            clone1 = Instantiate(ToletPapir, posRolna.position, posRolna.rotation);
            clone1.velocity = posRolna.forward * speedPower;

            Rigidbody clone2;
            clone2 = Instantiate(rolnica, posRolna.position + posRolna.right, posRolna.rotation);
            clone2.velocity = posRolna.right * rolnaSpeed;
            municijaToletPapir -= 1;
            text.text = "x" + municijaToletPapir.ToString();


        }
    }

    void FixedUpdate()
    {
        AnimatorStateInfo info = anime.GetCurrentAnimatorStateInfo(0);
        if (info.IsName("Fire"))anime.SetBool("Fire", false);
    }


        public void pucanjeRolnama(int a)
        {
        
        num = a;
         }
        public void pucanjeToletPapirim(int a)
        {
        
        num = a;
        }
        void OnCollisionEnter(Collision collision)
        {

            if (collision.gameObject.tag == "PaketToletPapira")
            {
                soundFire.Play("PickUp");
                Destroy(collision.gameObject);
                municijaToletPapir += 6;
                text.text = "x" + municijaToletPapir.ToString();
            }

            if (collision.gameObject.tag == "Gold")
            {
                soundFire.Play("GoldPickUp");
                scoreSystem += 25;
                score.text = scoreSystem.ToString();
                Destroy(collision.gameObject);
            }

        
        }
 
}
 