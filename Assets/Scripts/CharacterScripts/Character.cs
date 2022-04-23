using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    

    private LifeSituation lifeSituation;
    // Start is called before the first frame update
    void Start()
    {
        lifeSituation = LifeSituation.Alive;
    }

    // Update is called once per frame
    void Update()
    {
        LifeSituationHandler();
    }

    public void LifeSituationHandler()
    {
        if (lifeSituation == LifeSituation.Alive)
        {
            
        }
        else if(lifeSituation == LifeSituation.Death)
        {
            //TODO Disable all control and other things.
            //Debug.Log("Enum LifeSituation death");
        }
        else
        {
            Debug.Log("Unexpected Situation");
        }
    }

    public void Death()
    {
        lifeSituation = LifeSituation.Death;
    }
}
