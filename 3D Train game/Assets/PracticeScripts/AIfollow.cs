﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIfollow : MonoBehaviour
{

    //controls
    //change rail types
    //public float xDirection = 0f;
    //public float yDirection = 0f;
    //public float zDirection = 2f;

    /////
    public Vector3 OldPosition;
    public GameObject rail;
    public LinkedList<GameObject> myLinkedList;
    //////
    public Transform target;
    public float speeed;
    GameObject actualRail;

    void Awake()
    {
        OldPosition = target.position;
        target = target.GetChild(0);
        Debug.Log("update");
        myLinkedList = new LinkedList<GameObject>();
        //actualRail = Instantiate(rail);
        
        
        print(myLinkedList.Count);
    }
    void Update()
    { //@TODO }

        if(myLinkedList.Count !=0)
        {
            target = myLinkedList.Last.Value.transform;
        }


        ///////
        float step = speeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);

        ////Update movement
        
        if (Input.GetKeyDown("space"))
        {
            Vector3 newPosition = new Vector3(0, 0, 0);


            /// control type of rail 
            /// 
            //if state
            if (myLinkedList.Count != 0)
            {
                newPosition = myLinkedList.Last.Value.transform.parent.position + new Vector3(0, 0, 2);
            }
            else
            {
                newPosition = OldPosition + new Vector3(0, 0, 2); //Controls location of new rail. 
            }

            actualRail = Instantiate(rail, newPosition, rail.transform.rotation);
            myLinkedList.AddLast(actualRail.transform.GetChild(0).gameObject);
            print(myLinkedList.Count);
        }


    }
}
