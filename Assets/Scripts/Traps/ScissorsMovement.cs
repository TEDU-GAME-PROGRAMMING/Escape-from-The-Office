using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScissorsMovement : MonoBehaviour
{
    public GameObject child;

    public Quaternion OpeningTargetDir;
    public Quaternion ClosingTargetDir;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (child.transform.rotation.y <= -45)
        {
            CloseScissor();
            Debug.Log("Kapat");
        }

        if (child.transform.rotation.y >= 0)
        {
            OpenScissors();
            Debug.Log("Ac");
        }
    }

    public void OpenScissors()
    {
        child.transform.rotation = Quaternion.Lerp(child.transform.rotation, OpeningTargetDir, 0.1f);
    }

    public void CloseScissor()
    {
        child.transform.rotation = Quaternion.Lerp(child.transform.rotation, ClosingTargetDir, 0.1f);
    }
}
