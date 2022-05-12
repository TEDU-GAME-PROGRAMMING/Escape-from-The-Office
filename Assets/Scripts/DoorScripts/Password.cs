using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Password : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI  Answer;
    public string Ans = "26159";

    public DoorHandler LinkedDoor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Number(int number){
        if(Answer.text == "Incorrect")
        {
            Answer.text = "";
        }
        Answer.text  += number.ToString();
    }

    
    public void Enter(){
        if(Answer.text == Ans){
            Answer.text = "Correct";
            WaitForResult();
            this.gameObject.SetActive(false);
            LinkedDoor.OpeningDoor();
            LinkedDoor.isOpened = true;
            CharacterMovements charMovements = FindObjectOfType<CharacterMovements>();
            charMovements.isPlayerEnable = true;
        }
        else{
            Answer.text = "Incorrect";
        }
    }
    IEnumerator WaitForResult()
    {
        yield return new WaitForSeconds(3);
    }
}
