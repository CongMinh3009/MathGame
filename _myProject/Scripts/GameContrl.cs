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
            // xử lý nếu random oper là chia 
                int temp = UnityEngine.Random.Range(1, 5);
                number2 = UnityEngine.Random.Range(1,10);
                number1 = temp * number2;
            }
           else if(oper == 1)
            {
            // xử lý nếu random oper là trừ
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
        int TYPE_QUESTION = UnityEngine.Random.Range(0, 4);
        int relust = RelustAnswer(n1,n2,oper);
        // tạo chấm hỏi để tạo các loại câu hỏi cho user trả lời
        if(TYPE_QUESTION == 0)
        {
            QuestionNumber1.text = "?";
            QuestionNumber2.text = n2.ToString();
            Operator.text = GetOperator(oper);
            Relust.text = relust.ToString();
        }
        else if(TYPE_QUESTION == 1)
        {
            QuestionNumber1.text = n1.ToString();
            QuestionNumber2.text = "?";
            Operator.text = GetOperator(oper);
            Relust.text = relust.ToString();
        }
        else if(TYPE_QUESTION == 2)
        {
            QuestionNumber1.text = n1.ToString();
            QuestionNumber2.text = n2.ToString();
            Operator.text = GetOperator(oper);
            Relust.text = "?";
        }
        else if(TYPE_QUESTION == 3)
        {
            QuestionNumber1.text = n1.ToString();
            QuestionNumber2.text = n2.ToString();
            Operator.text = "?";
            Relust.text = relust.ToString();
        }
        //active animation cho ô bị châm hỏi
        QuestionNumber1.transform.parent.Find("Selected").gameObject.SetActive(TYPE_QUESTION == 0);
        QuestionNumber2.transform.parent.Find("Selected").gameObject.SetActive(TYPE_QUESTION == 1);
        Operator.transform.parent.Find("Selected").gameObject.SetActive(TYPE_QUESTION == 3);
        Relust.transform.parent.Find("Selected").gameObject.SetActive(TYPE_QUESTION == 2);

    }
    public string GetOperator(int oper)
    {
        if (oper == 0) return "+";
        else if (oper == 1) return "-";
        else if (oper == 2) return "*";
        else if (oper == 3) return "/";
        else return null;
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
