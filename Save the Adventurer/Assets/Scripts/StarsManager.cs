using UnityEngine;
using Firebase.Firestore;
using System.Collections.Generic;
using Firebase.Extensions;

public class CorrectAnswersManager : MonoBehaviour
{
    FirebaseFirestore db;

    void Start()
    {
        // Mendapatkan instance Firebase Firestore
        db = FirebaseFirestore.DefaultInstance;
    }

    public void SaveCorrectAnswer(string questionID, string correctAnswer)
    {
        // Membuat referensi dokumen baru di koleksi "CorrectAnswers"
        DocumentReference docRef = db.Collection("CorrectAnswers").Document(questionID);

        // Membuat data untuk disimpan
        Dictionary<string, object> data = new Dictionary<string, object>
        {
            { "CorrectAnswer", correctAnswer }
        };

        // Menyimpan data ke Firestore
        docRef.SetAsync(data).ContinueWithOnMainThread(task =>
        {
            if (task.IsCompleted)
            {
                Debug.Log("Correct answer for question " + questionID + " saved successfully.");
            }
            else if (task.IsFaulted)
            {
                Debug.LogError("Error saving correct answer for question " + questionID + ": " + task.Exception);
            }
        });
    }
}
