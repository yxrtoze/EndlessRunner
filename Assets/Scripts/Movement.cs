using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] float forceMag;
    [SerializeField] private float speed;
 
    [SerializeField] GameObject lan1Cube;
    [SerializeField] GameObject lan2Cube;
    [SerializeField] GameObject lan3Cube;

    private Vector3[] lanePos;

    int currentLaneIndex;
    int targetIndex;

    void Start()
    {
        Debug.Log("Start");
        lanePos = new Vector3[3];

        currentLaneIndex=1;
        lanePos[0]= lan1Cube.transform.position;
        lanePos[1]= lan2Cube.transform.position;
        lanePos[2]= lan3Cube.transform.position;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (currentLaneIndex!=0)
                targetIndex=currentLaneIndex-1;
                
            currentLaneIndex=targetIndex;

            Debug.Log(lanePos[targetIndex]);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (currentLaneIndex!=2)
                targetIndex=currentLaneIndex+1;
                
            currentLaneIndex=targetIndex; 

            Debug.Log(lanePos[targetIndex]);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * forceMag );
        }

        var step = speed * Time.deltaTime; //Calculate distance to move
        transform.position= Vector3.MoveTowards(transform.position, lanePos[targetIndex], step);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            Destroy(collision.gameObject);
        }
    }
}