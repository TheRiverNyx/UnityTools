using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class PlatformerAI : MonoBehaviour
{
    public Transform targetPosition;

    private Seeker seeker;

    public Path path;

    public float speed = 2;

    public float nextWaypointDistance = 2;

    private int currentWaypoint;

    public float repathRate = 0.5f;

    private float lastRepath = float.NegativeInfinity;

    public bool reachedEndOfPath;
    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
    }

    public void OnPathComplete(Path p)
    {
        Debug.Log("A path was calculated. Did it fail with an error? " + p.error);
        
        p.Claim(this);
        if (!p.error)
        {
            if (path != null)path.Release(this);
            path = p;

            currentWaypoint = 0;
        }else p.Release(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > lastRepath + repathRate && seeker.IsDone())
        {
            lastRepath = Time.time;

            seeker.StartPath(transform.position, targetPosition.position, OnPathComplete);
            
        }

        if (path == null)
        {
            return;
        }

        reachedEndOfPath = false;
        float distanceToWaypoint;
        while (true)
        {
            distanceToWaypoint = Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]);
            if (distanceToWaypoint < nextWaypointDistance)
            {
                if (currentWaypoint + 1 < path.vectorPath.Count)
                {
                    currentWaypoint++;
                }
                else
                {
                    reachedEndOfPath = true;
                    break;
                }
            }
        }

        var speedFactor = reachedEndOfPath ? Mathf.Sqrt(distanceToWaypoint / nextWaypointDistance) : 1f;

        Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;

        Vector3 velocity = dir * (speedFactor * speed);
    }
}
