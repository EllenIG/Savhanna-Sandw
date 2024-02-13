using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AIController : MonoBehaviour
{
    // public Transform Player;
    //int MoveSpeed = 4;
    //int MaxDist = 10;
    //int MinDist = 5;

    public Transform target;
    public float speed = 2f;
    private float minDistance = 1f;
    private float range;





    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {

        range = Vector2.Distance(transform.position, target.position);

        if (range > minDistance)
        {
            Debug.Log(range);

        }
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);





        // transform.LookAt(Player);
        // if (Vector2.Distance(transform.position, Player.position) >= MinDist)
        // {

        //   transform.position += transform.forward * MoveSpeed * Time.deltaTime;



        // if (Vector2.Distance(transform.position, Player.position) <= MaxDist)
        {
            //Here Call any function U want Like Shoot at here or something
        }
        //}


    }
}