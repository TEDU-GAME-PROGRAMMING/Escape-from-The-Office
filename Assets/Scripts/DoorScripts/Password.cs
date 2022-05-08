using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Password : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI  Answer;
    private string Ans = "1234";

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
            LinkedDoor.OpenPasswordDoor();
        }
        else{
            Answer.text = "Incorrect";
        }
    }
    IEnumerator WaitForResult()
    {
        yield return new WaitForSeconds(2);
    }
}
