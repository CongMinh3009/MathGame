using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameContrl : MonoBehaviour
{
    public Text QuestionNumber1;
    public Text QuestionNumber2;
    public Text Operator; // + = 0 , - = 1 , * = 2, / = 3
    public Text Relust;
    public int Level; 

    private void OnEnable()
    {
        Application.targetFrameRate = 60;
        PlayGame();
    }

    void PlayGame()
    {
        ChooseOperator();
    }
    void ChooseOperator()
    {
        int op = 0;
        if (Level == 1) op = UnityEngine.Random.Range(0, 2);
        else if (Level <= 3) op = UnityEngine.Random.Range(0, 3);
        else op = UnityEngine.Random.Range(0, 4);
        CreateQuestion(op);
    }
    void CreateQuestion(int oper)
    {
        int number1;
        int number2;
       

           if(oper == 3)
            {
                int temp = UnityEngine.Random.Range(1, 5);
                number2 = UnityEngine.Random.Range(1,10);
                number1 = temp * number2;
            }
           else if(oper == 1)
            {
                number2 = UnityEngine.Random.Range(1, 10);
                number1 = UnityEngine.Random.Range(1 + number2 / 2, 10);
            }
           else
            {
                number1 = UnityEngine.Random.Range(1, 10);
                number2 = UnityEngine.Random.Range(1, 10);
            }
           SetText(number1,number2,oper);
      
    }
    void SetText(int n1 ,int  n2 ,int  oper )
    {
        int relust;
        QuestionNumber1.text = n1.ToString();
        QuestionNumber2.text = n2.ToString();

        if (oper == 0) Operator.text = "+";
        else if (oper == 1) Operator.text = "-";
        else if (oper == 2) Operator.text = "*";
        else Operator.text = "/";

        relust = RelustAnswer(n1, n2, oper);
        Relust.text = relust.ToString();
    }
    public int RelustAnswer(int n1, int n2, int oper)
    {
        if (oper == 0) return n1 + n2;
        else if (oper == 1) return n1 - n2;
        else if (oper == 2) return n1 * n2;
        else if(oper == 3) return n1 / n2;
        else return default;
    }
   
}
