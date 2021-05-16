using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent))]
public class EnemyAi : MonoBehaviour
{
    public string enemyColor = "";
    public GameObject deathEnemy;
    public GameObject deathRedEnemy;
    private NavMeshAgent agent;
    private Transform player;
    private Vector3 razdaljina;
    public float vidoKrug = 5;
    [Range(0, 360)]
    public float ugaoVidljivosti = 160;
    public float Health = 100;
    public LayerMask EnviromentMask;
    public bool visiblePlayer = false;
    [Range(0, 100)]
    public float frequncy = 10;
    public float speedFrequancy = 20;
    public float seachingTime = 5;
    public float seachingSpeed = 100;
    float ugao;
    public bool pogodjenToletPapirom = false;
    private AudioManager DieEnemy;

    float x;
    float z;
    public void chasePlayer(Vector3 point)
    {
        
        agent.SetDestination(point);
        
    }

    // Start is called before the first frame update
    void Start()
    {
        DieEnemy = FindObjectOfType<AudioManager>();
        agent = GetComponent<NavMeshAgent>();
        GameObject go = GameObject.Find("Player");
        if(go  != null)
        {
            agent.transform.position = new Vector3(agent.transform.position.x, agent.transform.position.y + 5, agent.transform.position.z);
            player = go.transform;
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        agent.transform.position = agent.transform.position + agent.transform.up *( Mathf.Sin(Time.time * speedFrequancy)  + 3)* (frequncy / 100);
        playerVisible();
        if (visiblePlayer == false)
        {
         
            if(seachingTime > 0)
            {
                agent.transform.position += agent.transform.forward/ seachingSpeed; 
                seachingTime -= Time.deltaTime;
            }
            else
            {
                seachingTime = Random.Range(5f, 15f);
                searchingForPlayer();
            }
        }
    }

    public void playerVisible()
    {
        if (player != null)
        {
            razdaljina = player.position - transform.position;

        if (vidoKrug > razdaljina.magnitude)
        {
             ugao = Vector3.Angle(transform.forward, razdaljina.normalized);

            if (ugao < ugaoVidljivosti / 2)
            {
                if (!Physics.Raycast(transform.position, razdaljina, razdaljina.magnitude, EnviromentMask))
                {
                    visiblePlayer = true;
                }


            }


            // visiblePlayer = false;
        }
        if (visiblePlayer == true || pogodjenToletPapirom == true)
        {

            chasePlayer(player.position);


        }
    }
    }
    void OnDrawGizmosSelected()
    {
        if (player != null)
        {
            // Draws a blue line from this transform to the target
            if(visiblePlayer)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawLine(transform.position, player.position);
            }
          

            Gizmos.color = Color.black;
            Gizmos.DrawLine(transform.position, transform.position + transform.forward * vidoKrug);

            Gizmos.color = Color.white;
            Gizmos.DrawWireSphere(transform.position, vidoKrug);

            Gizmos.color = Color.black;
            Gizmos.DrawLine(transform.position,vectorAngle((/*angle + */90 - ugaoVidljivosti/2 - transform.rotation.eulerAngles.y ) * Mathf.Deg2Rad, vidoKrug, transform.position));

            Gizmos.color = Color.black;
            Gizmos.DrawLine(transform.position, vectorAngle((/*angle + */90 + ugaoVidljivosti/2 - transform.rotation.eulerAngles.y ) * Mathf.Deg2Rad, vidoKrug, transform.position));


        }
    }

    public Vector3 vectorAngle(float angle, float magnituda, Vector3 center)
    {
         x = magnituda * Mathf.Cos(angle);
         z = magnituda * Mathf.Sin(angle);
        return new Vector3(center.x + x, center.y ,center.z + z);
    }

    public void Damage(float dmgDeal)
    {
        Health -= dmgDeal;
        if (Health <= 0)
        {
            if(enemyColor == "Green")
            {
                GameObject effect = (GameObject)Instantiate(deathEnemy, transform.position, Quaternion.identity);
                Destroy(effect, 5);
                DieEnemy.Play("DieEnemy");
                Destroy(gameObject);
            }
            else if(enemyColor == "Red")
            {
                GameObject effect = (GameObject)Instantiate(deathRedEnemy, transform.position, Quaternion.identity);
                Destroy(effect, 5);
                DieEnemy.Play("DieEnemy");
                Destroy(gameObject);
            }
         
        }
    }

    void searchingForPlayer()
    {
        agent.transform.eulerAngles = new Vector3(0, Random.Range(0, 360), 0);
    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Municija")
        {
            pogodjenToletPapirom = true;
        }

        }

    


}
