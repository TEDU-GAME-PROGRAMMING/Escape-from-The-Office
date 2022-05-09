using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrinterTrapHandler : MonoBehaviour
{
    public GameObject planePrefab;

    public float speed = 2f;

    private float Fire = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Fire <= 0)
        {
           
            GameObject newPlane = Instantiate(planePrefab, new Vector3(transform.position.x + 0, transform.position.y + 0.2f, transform.position.z + 0.5f), Quaternion.identity);
            newPlane.GetComponent<Rigidbody>().velocity = newPlane.transform.forward * speed;
            Fire = 3f;

        }
        Fire -= Time.deltaTime ;
    }
  
}
