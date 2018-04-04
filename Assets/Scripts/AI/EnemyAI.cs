using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour 
{
    public delegate void ChangeWaypoints();
    ChangeWaypoints UpdateWaypoint;

    [SerializeField] NavMeshAgent agent;
    [SerializeField] GameObject[] wayPoints;
    [SerializeField] int currentWaypointIdx = 0;
    [SerializeField] float dist;
    [SerializeField] Rigidbody rb;

    void Awake()
    {
        wayPoints = new GameObject[5];
        wayPoints[0] = GameObject.Find("Waypoint");
        wayPoints[1] = GameObject.Find("Waypoint (1)");
        wayPoints[2] = GameObject.Find("Waypoint (2)");
        wayPoints[3] = GameObject.Find("Waypoint (3)");
        wayPoints[4] = GameObject.Find("Waypoint (4)");
    }

	void Start () 
    {
        agent.SetDestination(wayPoints[currentWaypointIdx].transform.position);
        UpdateWaypoint += WaypointUpdate;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {
        dist = Vector3.Distance(transform.position, wayPoints[currentWaypointIdx].transform.position);

        if(dist < 3f)
            UpdateWaypoint();
	}

    public void WaypointUpdate()
    {
        if (currentWaypointIdx != wayPoints.Length)
        {            
            currentWaypointIdx++;

            // Set the agent destination
            agent.SetDestination(wayPoints[currentWaypointIdx].transform.position);
        }
    }
}
