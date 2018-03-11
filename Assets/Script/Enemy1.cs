using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour {

    public float speed = 10.0f;

    private Transform[] positions;
    private int index = 0;

	// Use this for initialization
	void Start () {
        positions = WayPoints.positions;
	}
	
	// Update is called once per frame
	void Update () {
        Move();
	}

    void Move()
    {
        if (index > positions.Length - 1) return;
        transform.Translate((positions[index].position - transform.position).normalized * speed * Time.deltaTime);
        if(Vector3.Distance(transform.position, positions[index].position) < 0.2f)
        {
            index++;
            if (index == positions.Length)
            {
                ReachDestination();
            }
        }
    }

    void ReachDestination()
    {
        GameObject.Destroy(this.gameObject);
    }

    void OnDestroy()
    {
        EnemySpawner.CountEnemyAlive--;
    }
}
