using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healing : MonoBehaviour
{
    public GameObject healCylindar;
    public GameObject healPosition;
    private Renderer materijalObjekta;
    private Renderer materijalCylindra;
    public float healing = 10;
    private GameObject player;
    private float krugHilanja = 2;
    public float vremeHeala = 120;
    public float pocentoVreme = 0;
    public HealthBarScript healthBar;
    private bool hilaSe = true;
    private bool obojen = true;
    // Start is called before the first frame update
    void Start()
    {
      
        materijalObjekta = healPosition.GetComponent<Renderer>();
        materijalCylindra = healCylindar.GetComponent<Renderer>();
       
        player = GameObject.Find("Player");
        pocentoVreme = vremeHeala;
       
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            if (pocentoVreme > vremeHeala)
            {
                obojen = false;
                if (obojen == false)
                {
                    materijalObjekta.material.color = new Color(0.1843137f, 0.7490196f, 0.4431372f, 1f);
                    materijalCylindra.material.color = new Color(0.1843137f, 0.7490196f, 0.4431372f,0.5f);
                    
                    obojen = true;
                }
            }
                Vector3 razdaljina = player.transform.position - transform.position;
            if (razdaljina.magnitude < krugHilanja)
            {
                if (pocentoVreme > vremeHeala  )
                {
                    hilaSe = true;
                   
                    
                        Health.health += healing;
                        healthBar.SetHealth(Health.health);
                    if (Health.startHealth <= Health.health)
                    {
                        pocentoVreme = 0;
                    }
                    
                    
                }


            }
            else
            {
                if(hilaSe == true)
                {
                    if (obojen == true)
                    {
                        materijalObjekta.material.color = new Color(0.9607843f, 0.8039216f, 0.4745098f,1f);
                        materijalCylindra.material.color = new Color(0.9607843f, 0.8039216f, 0.4745098f,0.2f);
                        obojen = false;
                    }
                    hilaSe = false;
                    pocentoVreme = 0;
                }
                pocentoVreme += Time.deltaTime;
            }
        }
        
    }

    void OnDrawGizmosSelected()
    {
            Gizmos.color = Color.white;
            Gizmos.DrawWireSphere(transform.position, krugHilanja);

        
    }
}
