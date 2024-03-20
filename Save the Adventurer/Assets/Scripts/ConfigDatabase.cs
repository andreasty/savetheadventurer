using UnityEngine;
using TMPro;
using Firebase;
using Firebase.Database;
using UnityEngine.UI;

public class ConfigDatabase : MonoBehaviour
{
    DatabaseReference reference;
    public TMP_Text questionText;
    public Button optionAButton;
    public Button optionBButton;
    public Button optionCButton;
    public Button optionDButton;
    public string questionIdToFetch = "Q0001"; // Change this to the ID of the question you want to fetch

    void Start()
    {
        // Initialize Firebase
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            if (task.IsCompleted)
            {
                FirebaseApp app = FirebaseApp.DefaultInstance;
                reference = FirebaseDatabase.DefaultInstance.GetReference("Questions").Child(questionIdToFetch);
                ReadDataFromDatabase();
            }
            else
            {
                Debug.LogError("Failed to initialize Firebase: " + task.Exception);
            }
        });
    }

    void ReadDataFromDatabase()
    {
        reference.GetValueAsync().ContinueWith(task =>
        {
            if (task.IsFaulted)
            {
                Debug.LogError("Failed to read data: " + task.Exception);
                return;
            }
            else if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;

                string question = snapshot.Child("Question").Value.ToString();
                string optionA = snapshot.Child("Option A").Value.ToString();
                string optionB = snapshot.Child("Option B").Value.ToString();
                string optionC = snapshot.Child("Option C").Value.ToString();
                string optionD = snapshot.Child("Option D").Value.ToString();

                // Update TextMeshPro Text objects
                questionText.text = question;
                optionAButton.GetComponentInChildren<TextMeshProUGUI>().text = optionA;
                optionBButton.GetComponentInChildren<TextMeshProUGUI>().text = optionB;
                optionCButton.GetComponentInChildren<TextMeshProUGUI>().text = optionC;
                optionDButton.GetComponentInChildren<TextMeshProUGUI>().text = optionD;

                Debug.Log("Data fetched successfully!");
            }
        });
    }
}
