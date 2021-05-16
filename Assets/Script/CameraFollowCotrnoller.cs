using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowCotrnoller : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    public float followSpeed = 10;
    public float lookSpeed = 10;
    public float ugaoGledanja = 2;
    Vector3 carPos;
    Vector3 direction;
    Quaternion rotation;




    public void Start()
    {
        GameObject go = GameObject.Find("Player");
        player = go.transform;
    }

    public void LookAtTarget()
    {
        if (player != null)
        {

             direction = ugaoGledanja * transform.up + player.position - transform.position;
             rotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, lookSpeed * Time.deltaTime);
        }
    }
    public void MoveToTarget()
    {
        if (player != null)
        {
             carPos = player.position +
            player.forward * offset.z +
            player.right * offset.x +
            player.up * offset.y;

            transform.position = Vector3.Lerp(transform.position, carPos, followSpeed * Time.deltaTime);
        }
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        
            LookAtTarget();
            MoveToTarget();
        
       
    }
}
