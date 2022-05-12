using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinaryLeverDoor : MonoBehaviour
{
    public List<Lever> Levers;
    public int Answer;
    public string BinaryAnswer;
    public List<bool> TrueLeverCount;
    
    public DoorHandler LeverDoor;

    public bool isOpened = false;
    // Start is called before the first frame update
    void Start()
    {
        BinaryAnswer = System.Convert.ToString(Answer, 2);
        Debug.Log(BinaryAnswer + " " + Levers.Count);
        //TrueLeverCount = new List<int>(BinaryAnswer.Length);
    }

    // Update is called once per frame
    void Update()
    {
        
        LeverAnswerCheck();
        
        
    }

    public void LeverAnswerCheck()
    {
        for (int i = 0; i < BinaryAnswer.Length; i++)
        {
            
            if (BinaryAnswer[i] == '1')
            {
               
                if (Levers[i].isActive)
                {
                    TrueLeverCount[i] = true;
                    
                }
                else
                {
                    TrueLeverCount[i] = false;
                }
              
            }
            else
            {
                
                if (!Levers[i].isActive)
                {
                    
                    TrueLeverCount[i] = true;
                    
                }
                else
                {
                    TrueLeverCount[i] = false;
                }
                
            }
        }

        if (!TrueLeverCount.Contains(false) && !isOpened)
        {
            
            LeverDoor.OpeningDoor();
            isOpened = true;
        }
    }
}
