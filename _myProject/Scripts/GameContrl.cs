using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameContrl : MonoBehaviour
{
    [Header("Create Number Question Text")]
    public Text QuestionNumber1;
    public Text QuestionNumber2;
    public Text Operator; // + = 0 , - = 1 , * = 2, / = 3
    public Text Relust;
    [Header("Audio")]
    public AudioClip MusicBG;
    [Header("Score")]
    public int Score = 0;
    [Header("Answer Box Text")]
    public Text[] Answer;

    [Header("Others")]
    public int RightAnswer;
    public int TotalTime = 60;
    public Slider Slider;
    private void OnEnable()
    {
        Application.targetFrameRate = 60;
        PlayGame();
    }
    public void PlayMusic()
    {
        GetComponent<AudioSource>().Play();
    }
    void PlayGame()
    {
        StartCoroutine(TimePlay());
        ChooseOperator();
        PlayMusic();
    }
    void ChooseOperator()
    {
        int op = 0;
        if (Score == 1) op = UnityEngine.Random.Range(0, 2);
        else if (Score <= 3) op = UnityEngine.Random.Range(0, 3);
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
    IEnumerator TimePlay()
    {
        Slider.maxValue = TotalTime;
        Slider.value = TotalTime;
        while(true)
        {
            float timer = 0.2f;
            Slider.value -= timer;
            if (Slider.value == 0)
                break;
            yield return new WaitForSeconds(0.01f);
        }
       
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
            RightAnswer = n1;
        }
        else if(TYPE_QUESTION == 1)
        {
            QuestionNumber1.text = n1.ToString();
            QuestionNumber2.text = "?";
            Operator.text = GetOperator(oper);
            Relust.text = relust.ToString();
            RightAnswer = n2;

        }
        else if(TYPE_QUESTION == 2)
        {
            QuestionNumber1.text = n1.ToString();
            QuestionNumber2.text = n2.ToString();
            Operator.text = GetOperator(oper);
            Relust.text = "?";
            RightAnswer = relust;

        }
        else if(TYPE_QUESTION == 3)
        {
            QuestionNumber1.text = n1.ToString();
            QuestionNumber2.text = n2.ToString();
            Operator.text = "?";
            Relust.text = relust.ToString();
            RightAnswer = oper;


        }
        //active animation cho ô bị châm hỏi
        QuestionNumber1.transform.parent.Find("Selected").gameObject.SetActive(TYPE_QUESTION == 0);
        QuestionNumber2.transform.parent.Find("Selected").gameObject.SetActive(TYPE_QUESTION == 1);
        Operator.transform.parent.Find("Selected").gameObject.SetActive(TYPE_QUESTION == 3);
        Relust.transform.parent.Find("Selected").gameObject.SetActive(TYPE_QUESTION == 2);

        if(TYPE_QUESTION != 3)
        {
            int[] answer = new int[4];
            List<int> AnswerList = new List<int>();
            AnswerList.Add(RightAnswer);
            int tempAns;
            bool temp = true;
            while(true)
            {
                while(true)
                {
                    tempAns = UnityEngine.Random.Range(1, relust * 2 + 3);
                    if (tempAns <= 0)
                        temp = false;
                    if (temp) break;
                }
                if (!AnswerList.Contains(tempAns))
                    AnswerList.Add(tempAns);
                if (AnswerList.Count == 4)
                    break;
            }
            answer = AnswerList.ToArray();
            Array.Sort(answer);
            
            for(int i = 0; i <= 4 ;i++)
            {
                Answer[i].fontSize = 120;
                Answer[i].text = answer[i].ToString();
            }
        }
        else
        {
            Answer[0].text = "+";
            Answer[0].fontSize = 120;

            Answer[1].text = "-";
            Answer[1].fontSize = 120;

            Answer[2].text = "*";
            Answer[3].text = "/";
            Answer[3].fontSize = 120;

        }
    }
    public void Click(Text text)
    {
        int myAnswer = 0;
        if (text.text.Contains("+"))
            myAnswer = 0;
        else if (text.text.Contains("-"))
            myAnswer = 1;
        else if (text.text.Contains("*"))
            myAnswer = 2;
        else if (text.text.Contains("/"))
            myAnswer = 3;
        else
            myAnswer = int.Parse(text.text);
        if(RightAnswer == myAnswer)
        {
            Score++;
        }
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
