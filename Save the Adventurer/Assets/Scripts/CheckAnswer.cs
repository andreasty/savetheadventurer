using UnityEngine; 
using UnityEngine.UI; 
using Firebase.Firestore;
using System.Collections.Generic;
using Firebase.Extensions;
using TMPro;
using System.Collections;

public class CheckAnswer : MonoBehaviour
{
    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;
    public Color correctColor = Color.green;
    public Color wrongColor = Color.red;
    private Color originalColor;
    public float colorChangeDuration = 1f;
    public static CheckAnswer Instance;
    private string clickedButtonValue;
    private int clickedButtonNumber; 

    void Start(){
        FirebaseFirestore db = FirebaseFirestore.DefaultInstance;
        CollectionReference questionsRef = db.Collection("QuestionsBank");
        DocumentReference docRef = questionsRef.Document("Q0001");

        docRef.GetSnapshotAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsFaulted)
            {
                Debug.LogError("Error getting document: " + task.Exception);
                return;
            }

            DocumentSnapshot snapshot = task.Result;
            if (snapshot.Exists)
            {
                Dictionary<string, object> data = snapshot.ToDictionary();

                string answer = data["Answer"].ToString();
                answerValue = answer;

                Debug.Log("Jawaban Benar : " + answerValue);
            }
            else
            {
                Debug.LogError("Document does not exist!");
            }
        });
    }
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetClickedButtonValue(string value, int buttonNumber)
    {
        clickedButtonValue = value;
        clickedButtonNumber = buttonNumber;
        Debug.Log("Clicked button value set to: " + clickedButtonValue);
        // CheckingAnswer();
    }

    public string GetClickedButtonValue()
    {
        return clickedButtonValue;
    }
    
    public int GetClickedButtonNumber()
    {
        return clickedButtonNumber;
    }

    private string answerValue;
    public void CheckingAnswer()
    {
        if (clickedButtonValue == button1.GetComponentInChildren<TextMeshProUGUI>().text)
        {
            StartCoroutine(ChangeButtonColor(button1, answerValue == clickedButtonValue ? correctColor : wrongColor));
        }
        else if (clickedButtonValue == button2.GetComponentInChildren<TextMeshProUGUI>().text)
        {
            StartCoroutine(ChangeButtonColor(button2, answerValue == clickedButtonValue ? correctColor : wrongColor));
        }
        else if (clickedButtonValue == button3.GetComponentInChildren<TextMeshProUGUI>().text)
        {
            StartCoroutine(ChangeButtonColor(button3, answerValue == clickedButtonValue ? correctColor : wrongColor));
        }
        else if (clickedButtonValue == button4.GetComponentInChildren<TextMeshProUGUI>().text)
        {
            StartCoroutine(ChangeButtonColor(button4, answerValue == clickedButtonValue ? correctColor : wrongColor));
        }
    }

    IEnumerator ChangeButtonColor(Button button, Color targetColor)
    {
        Color originalButtonColor = button.image.color;
        button.image.color = targetColor;

        yield return new WaitForSeconds(colorChangeDuration);

        button.image.color = originalButtonColor;
    }
}