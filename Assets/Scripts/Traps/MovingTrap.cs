using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTrap : MonoBehaviour
{
    public GameObject TrapObj;
       public List<Transform> checkpointPositions;
       public float speed = 1f;
       public int ind = 1;
       // Start is called before the first frame update
       void Start()
       {
           TrapObj.transform.position = checkpointPositions[0].position;
       }
   
       // Update is called once per frame
       void Update()
       {
           TrapObj.transform.position = Vector3.MoveTowards(TrapObj.transform.position, checkpointPositions[ind].position, speed*Time.deltaTime);
           if (Vector3.Distance(TrapObj.transform.position, checkpointPositions[ind].position) <= 0.05f)
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
