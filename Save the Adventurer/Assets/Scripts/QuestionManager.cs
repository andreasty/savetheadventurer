using UnityEngine;
using UnityEngine.UI;
using Firebase.Firestore;
using System.Collections.Generic;
using Firebase.Extensions;
using TMPro;
using System;
using System.Collections;

public class QuestionManager : MonoBehaviour
{
    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;
    public TMP_Text questionText;
    public TMP_Text optionAText;
    public TMP_Text optionBText;
    public TMP_Text optionCText;
    public TMP_Text optionDText;
    public Color correctColor = Color.green;
    public Color wrongColor = Color.red;
    public float colorChangeDuration = 1f;
    public int maxQuestionLimit = 20;
    private int questionCounter = 0;
    public GameObject panel;
    public GameObject StarImage1;
    public GameObject StarImage2;
    public GameObject StarImage3;
    private string clickedButtonValue;
    private int clickedButtonNumber;
    private string answerValue;
    private int currentQuestionNumber = 1;
    private bool sessionFinished = false;
    private bool isLoadingQuestion = false;
    private int correctAnswerCount = 0;
    private int correctAnswerPercentage;


    void Start()
    {
        LoadQuestion("Q0001");
    }

    void LoadQuestion(string questionID)
    {
        if (questionCounter >= maxQuestionLimit)
        {
            Debug.Log("Maximum question limit reached.");

            float correctPercentage = CalculateCorrectAnswerPercentage();
            Debug.Log("Persentase jawaban benar: " + correctPercentage + "%");  
            ShowStars();
            panel.SetActive(true);
            sessionFinished = true;
            return;
        }

        if (isLoadingQuestion) return;

        isLoadingQuestion = true;

        FirebaseFirestore db = FirebaseFirestore.DefaultInstance;
        CollectionReference questionsRef = db.Collection("QuestionsBank");
        DocumentReference docRef = questionsRef.Document(questionID);

        docRef.GetSnapshotAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsFaulted)
            {
                Debug.LogError("Error getting document: " + task.Exception);
                isLoadingQuestion = false;
                return;
            }

            DocumentSnapshot snapshot = task.Result;
            if (snapshot.Exists)
            {
                Dictionary<string, object> data = snapshot.ToDictionary();

                string question = data["Question"].ToString();
                string optionA = data["Option A"].ToString();
                string optionB = data["Option B"].ToString();
                string optionC = data["Option C"].ToString();
                string optionD = data["Option D"].ToString();
                string answer = data["Answer"].ToString();

                questionText.text = question;
                optionAText.text = optionA;
                optionBText.text = optionB;
                optionCText.text = optionC;
                optionDText.text = optionD;

                answerValue = answer;
                questionCounter++;

                Debug.Log("Question Counter: " + questionCounter);
                Debug.Log("Correct Answer: " + answerValue);
            }
            else
            {
                Debug.LogError("Document does not exist!");
            }

            isLoadingQuestion = false;
        });
    }


    public void SetClickedButtonValue(string value, int buttonNumber)
    {
        button1.interactable = false;
        button2.interactable = false;
        button3.interactable = false;
        button4.interactable = false;

        clickedButtonValue = value;
        clickedButtonNumber = buttonNumber;
        Debug.Log("Clicked button value set to: " + clickedButtonValue);
        // CheckingAnswer();
    }

    public void CheckingAnswer()
    {
        if (clickedButtonValue == answerValue)
        {
            StartCoroutine(ChangeButtonColor(GetButtonByNumber(clickedButtonNumber), correctColor));
            correctAnswerCount++;
            Debug.Log("Jumlah jawaban benar: " + correctAnswerCount);
        }
        else
        {
            StartCoroutine(ChangeButtonColor(GetButtonByNumber(clickedButtonNumber), wrongColor));
        }

        StartCoroutine(LoadNextQuestionWithDelay());
    }

    public int CorrectAnswerCount
    {
        get { return correctAnswerCount; }
    }

    IEnumerator LoadNextQuestionWithDelay()
    {
        yield return new WaitForSeconds(1f);

        if (!isLoadingQuestion && !sessionFinished)
        {
            currentQuestionNumber++;
            string nextQuestionID = "Q" + currentQuestionNumber.ToString().PadLeft(4, '0');
            LoadQuestion(nextQuestionID);

            button1.interactable = true;
            button2.interactable = true;
            button3.interactable = true;
            button4.interactable = true;
        }
        else if (sessionFinished && questionCounter <= maxQuestionLimit)
        {
            Debug.Log("Session finished.");
        }
    }

    public float CalculateCorrectAnswerPercentage()
    {
        if (questionCounter == 0)
        {
            return 0f; // Menghindari pembagian oleh nol
        }
        else
        {
            return ((float)correctAnswerCount / questionCounter) * 100f;
        }
    }

    public void ShowStars(){
        float correctPercentage = CalculateCorrectAnswerPercentage();
        if (correctPercentage == 100)
        {
            StarImage3.SetActive(true);
            Debug.Log("You got 3 Stars");
        }
        else if (correctPercentage >= 80 && correctPercentage < 100)
        {
            StarImage2.SetActive(true);
            Debug.Log("You got 2 Stars");
        }
        else if (correctPercentage >= 50 && correctPercentage < 80)
        {
            StarImage1.SetActive(true);
            Debug.Log("You got 1 Star");
        }
        else
        {
            Debug.Log("You failed");
        }
    }
    Button GetButtonByNumber(int buttonNumber)
    {
        switch (buttonNumber)
        {
            case 1:
                return button1;
            case 2:
                return button2;
            case 3:
                return button3;
            case 4:
                return button4;
            default:
                return null;
        }
    }

    IEnumerator ChangeButtonColor(Button button, Color targetColor)
    {
        Color originalButtonColor = button.image.color;
        button.image.color = targetColor;

        yield return new WaitForSeconds(colorChangeDuration);

        button.image.color = new Color(0.2f, 0.44f, 0.59f);
    }
}
