using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRotate : MonoBehaviour
{
    private float Rotate = 3f;

    public float RotateAngle = 45;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Rotate <= 0)
        {
           
            transform.Rotate(0,RotateAngle,0);
            Rotate = 3f;

        }
        Rotate -= Time.deltaTime ;
    }
}
