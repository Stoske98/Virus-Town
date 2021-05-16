using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    public Animator anime;
    public GameObject maskaSlika;
   // public GameObject maska;
    public float maxProtect = 100;
    private float protect = 0;
    public static float health = 110;
    public static float startHealth = 0;
    public static int brojZarazenih =0;
    public bool zarazen = false;
    private int z = 0;
    public int pilula = 0;
    public HealthBarScript healthBar;
    public ProtectBarScript protectBar;
    private AudioManager PickUp;

    public Text textZaZarazene;
    public Text textZaPilule;

    // Start is called before the first frame update
    void Start()
    {
        maskaSlika.SetActive(false);
        pilula = 0;
        textZaPilule.text = "x" + pilula;
        textZaZarazene.text = "Infected x" + brojZarazenih;
        PickUp = FindObjectOfType<AudioManager>();
        health = 110;
        startHealth += health;
        healthBar.SetMaxHealth(health);
        protectBar.SetMaxProtect(maxProtect);
        protectBar.SetProtect(0);

    }

    // Update is called once per frame
    void Update()
    {
        healthBar.SetHealth(health);
        if (health > startHealth)
        {
            health = startHealth;
            healthBar.SetHealth(health);
        }
        if(zarazen && brojZarazenih >0)
        {


            health -= 1f / 100f * brojZarazenih;
            healthBar.SetHealth(health);
            if (health < 3)
            {
                health = 3;

            }
        }
       
    }

    public void Damage()
    {
        if (protect > 0)
        {
            //dmg koji deluje za protect
            protect -= 100;
            protectBar.SetProtect(protect);
            maskaSlika.SetActive(false);
            if (protect <= 0 )
            {
                z = 1;
            }
            
        }
  

    }

    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "Enemy" )
        {
            PickUp.Play("Infected");
            Damage();
            Destroy(collision.gameObject);
          if(z != 1)
            {
                brojZarazenih++;
                textZaZarazene.text = "Infected x" + brojZarazenih;
                zarazen = true;
            }
            z--;
               
          
           
            //MovementPlayer player = GetComponent<MovementPlayer>();
            //player.playerSpeed = player.playerSpeed / 100 * 75;
           
        }
        if (collision.gameObject.tag == "Protect")
        {
            PickUp.Play("PickUp");
            Destroy(collision.gameObject);
            protect += 100;
            if (protect > 100 )
            {
                protect = 100;
            }
            maskaSlika.SetActive(true);
            protectBar.SetProtect(protect);

           
      
        }

        if (collision.gameObject.tag == "Pilula")
        {
            PickUp.Play("PickUp");
            pilula++;
            textZaPilule.text = "x" + pilula;
            Destroy(collision.gameObject);
          

        }



    }


    public void iskoristiPilulu()
    {
        if(pilula > 0)
        {
            zarazen = false;
            pilula--;
            textZaPilule.text = "x" + pilula;
            brojZarazenih = 0;
            textZaZarazene.text = "Infected x" + brojZarazenih;
        }
    
    }
}
