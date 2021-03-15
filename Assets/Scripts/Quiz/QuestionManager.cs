using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuestionManager : MonoBehaviour
{
    public static QuestionManager instance;

    public GameObject questionHolder;
    public GameObject topBar;
    public GameObject summaryHolder;

    public GameObject correctIcon;
    public GameObject incorrectIcon;

    public Text questionNumber;
    public Text questionText;
    public Text choice1_Text;
    public Text choice2_Text;
    public Text choice3_Text;
    public Text choice4_Text;

    public Button choice1_Button; 
    public Button choice2_Button;
    public Button choice3_Button;
    public Button choice4_Button;

    public string nextScene = "NextScene";
    public string mainMenuScene = "MainMenuMenu";

    public Color defaultButtonColor ;
    public Color CorrectButtonColor ;

    public List<Question> questions = new List<Question>();

    public int numChoice = 4;
    public string tempString;
    public int keyIndex;
    string[] choiceArray;

    public int currentQuestion = 0;

    public int scoreToAdd = 100;
    public int scoreToRedure = 100;

    public bool isWait;

    private void Start()
    {
        instance = this;

        questions.Add(new Question(1, "ยาเสพติดประเภทที่ 1 เป็นยาเสพติดออกฤทธิ์อย่างไร", "กดประสาท", "หลอนประสาท", "กระตุ้นประสาท", "ผสมผสาน", 1, 100));
        questions.Add(new Question(2, "ยาเสพติดประเภทกดประสาทส่งผล", "ยาบ้า", "เหล้า", "บุหรี่", "ยาอี", 2, 100));

        nextQuestion();
        
    }

    private void Update()
    {
        if (isWait)
        {
            choice1_Button.enabled = false;
            choice2_Button.enabled = false;
            choice3_Button.enabled = false;
            choice4_Button.enabled = false;

            if (Input.anyKeyDown)
            {
                currentQuestion++;

                correctIcon.SetActive(false);
                incorrectIcon.SetActive(false);

                nextQuestion();

                choice1_Button.enabled = true;
                choice2_Button.enabled = true;
                choice3_Button.enabled = true;
                choice4_Button.enabled = true;
            }
        }
    }

    public void nextQuestion()
    {
        isWait = false;

        choiceArray = new string[] { questions[currentQuestion].choice1, questions[currentQuestion].choice2, questions[currentQuestion].choice3, questions[currentQuestion].choice4 };
        keyIndex = questions[currentQuestion].key - 1;

        for (int i = 0; i < choiceArray.Length-1; i++)
        {
            int rnd = Random.Range(i, choiceArray.Length);
            tempString = choiceArray[rnd];
            choiceArray[rnd] = choiceArray[i];
            choiceArray[i] = tempString;

            if(rnd == keyIndex)
            {
                keyIndex = i;
            }else if(i == keyIndex)
            {
                keyIndex = rnd;
            }
        }

        if (currentQuestion < questions.Count)
        {
            questionNumber.text = questions[currentQuestion].questionNumber.ToString();

            choice1_Button.GetComponent<Image>().color = defaultButtonColor;
            choice2_Button.GetComponent<Image>().color = defaultButtonColor;
            choice3_Button.GetComponent<Image>().color = defaultButtonColor;
            choice4_Button.GetComponent<Image>().color = defaultButtonColor;

            questionText.text = questions[currentQuestion].question.ToString();
            choice1_Text.text = choiceArray[0].ToString();
            choice2_Text.text = choiceArray[1].ToString();
            choice3_Text.text = choiceArray[2].ToString();
            choice4_Text.text = choiceArray[3].ToString();
        }
        else
        {
            //deactive question ui and active summary ui
            questionHolder.SetActive(false);
            topBar.SetActive(false);
            summaryHolder.SetActive(true);
            //showscore
            //use FindObjectOfType<scoreManager>().currentScore;
        }
    }

    public void answerChoice1()
    {
        checkAnswer(0);
    }

    public void answerChoice2()
    {
        checkAnswer(1);
    }

    public void answerChoice3()
    {
        checkAnswer(2);
    }

    public void answerChoice4()
    {
        checkAnswer(3);
    }

    public void checkAnswer(int answer)
    {
        if(answer == keyIndex)
        {
            Debug.Log("correct answer");
            //show icon
            correctIcon.SetActive(true);
            //add score
            FindObjectOfType<scoreManager>().addScore(scoreToAdd);

            switch (keyIndex)
            {
                case 0:
                    choice1_Button.GetComponent<Image>().color = CorrectButtonColor;
                    break;
                case 1:
                    choice2_Button.GetComponent<Image>().color = CorrectButtonColor;
                    break;
                case 2:
                    choice3_Button.GetComponent<Image>().color = CorrectButtonColor;
                    break;
                case 3:
                    choice4_Button.GetComponent<Image>().color = CorrectButtonColor;
                    break;
            }

            isWait = true;
        }
        else
        {
            //redure score
            FindObjectOfType<scoreManager>().reduceScore(scoreToRedure);
            //show icon
            incorrectIcon.SetActive(true);
            //show right answer
            switch (keyIndex)
            {
                case 0:
                    choice1_Button.GetComponent<Image>().color = CorrectButtonColor;
                    break;
                case 1:
                    choice2_Button.GetComponent<Image>().color = CorrectButtonColor;
                    break;
                case 2:
                    choice3_Button.GetComponent<Image>().color = CorrectButtonColor;
                    break;
                case 3:
                    choice3_Button.GetComponent<Image>().color = CorrectButtonColor;
                    break;
            }
            //wait player click button or press any key then go to nextquestion
            isWait = true;
        }
    }

    public void loadNextScene()
    {
        SceneManager.LoadScene(nextScene);
    }

    public void loadMainMenu()
    {
        SceneManager.LoadScene(mainMenuScene);
    }
}
