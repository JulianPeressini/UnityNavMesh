using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PathFinder : MonoBehaviour
{

    [SerializeField] private GameObject[] waypoints = new GameObject[0];
    private NavMeshAgent self;

    private float CheckTargetInterval = 0.2f;
    private float CheckTargetTime = 2;

    private GameObject nextTarget;
    private GameObject lastTarget;

    private Renderer myRenderer;

    void Start()
    {
        self = GetComponent<NavMeshAgent>();    
        myRenderer = GetComponent<Renderer>();      
    }

    void Update()
    {
        if (nextTarget == null)
        {
            SetNewTarget();
        }
        else
        {
            if (Time.time > CheckTargetTime)
            {
                if (Vector3.Distance(gameObject.transform.position, nextTarget.transform.position) <= 1)
                {
                    SetNewTarget();
                }

                CheckTargetTime = Time.time + CheckTargetInterval;
            }
        }

            int targetPartners = nextTarget.GetComponent<WayPoint>().TargetersAmount;

            switch (targetPartners)
            {
                case 0:
                    myRenderer.material.SetColor("_Color", Color.cyan);
                    break;

                case 1:
                    myRenderer.material.SetColor("_Color", Color.yellow);
                    break;

                case 2:
                    myRenderer.material.SetColor("_Color", Color.magenta);
                    break;

                case 3:
                    myRenderer.material.SetColor("_Color", Color.red);
                    break;
            }
    }

    private void SetNewTarget()
    {
        nextTarget = GetRandomWaypoint();
        nextTarget.GetComponent<WayPoint>().IncrementTargeters();

        if (lastTarget == null)
        {
            lastTarget = nextTarget;
        }
        else if (lastTarget != nextTarget)
        {
            lastTarget.GetComponent<WayPoint>().DecreaseTargeters();
            lastTarget = nextTarget;
        }

        self.SetDestination(nextTarget.transform.position);
    }

    private GameObject GetRandomWaypoint()
    {
        int rmd = Random.Range(0, waypoints.Length);

        if (lastTarget != null)
        {
            while (waypoints[rmd] == lastTarget)
            {
                rmd = Random.Range(0, waypoints.Length);
            }

        }

        return waypoints[rmd];
    }
}
