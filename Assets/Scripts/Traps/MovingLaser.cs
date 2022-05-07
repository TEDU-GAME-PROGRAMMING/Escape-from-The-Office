using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovingLaser : MonoBehaviour
{
    public GameObject LaserObj;
    public List<Transform> checkpointPositions;
    private float speed = 1f;
    public int ind = 1;
    // Start is called before the first frame update
    void Start()
    {
        LaserObj.transform.position = checkpointPositions[0].position;
    }

    // Update is called once per frame
    void Update()
    {
        LaserObj.transform.position = Vector3.MoveTowards(LaserObj.transform.position, checkpointPositions[ind].position, speed*Time.deltaTime);
        if (Vector3.Distance(LaserObj.transform.position, checkpointPositions[ind].position) <= 0.05f)
        {
            ChangeCheckpoint();
        }

    }

    public void ChangeCheckpoint()
    {
        if (ind + 1 >= checkpointPositions.Count)
        {
                ind = 0;
        }
        else
        {
            ind++;
        }
        
    }
}
