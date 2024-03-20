using UnityEngine;
using UnityEngine.UI;
using Firebase.Firestore;
using System.Collections.Generic;
using Firebase.Extensions;
using TMPro;

public class FirestoreToCanvas : MonoBehaviour
{
    public TMP_Text questionText;
    public TMP_Text optionAText;
    public TMP_Text optionBText;
    public TMP_Text optionCText;
    public TMP_Text optionDText;
    public TMP_Text answerText;

    void Start()
    {
        // Mengambil referensi Firestore
        FirebaseFirestore db = FirebaseFirestore.DefaultInstance;
        // Mengambil referensi koleksi "Questions"
        CollectionReference questionsRef = db.Collection("QuestionsBank");
        // Mengambil dokumen dengan id "Q0001"
        DocumentReference docRef = questionsRef.Document("Q0001");

        // Mendapatkan data dari dokumen
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
                // Data dokumen tersedia
                Dictionary<string, object> data = snapshot.ToDictionary();

                // Mendapatkan nilai dari masing-masing field
                string question = data["Question"].ToString();
                string optionA = data["Option A"].ToString();
                string optionB = data["Option B"].ToString();
                string optionC = data["Option C"].ToString();
                string optionD = data["Option D"].ToString();
                string answer = data["Answer"].ToString();

                // Menampilkan data di Canvas
                questionText.text = question;
                optionAText.text = optionA;
                optionBText.text = optionB;
                optionCText.text = optionC;
                optionDText.text = optionD;
            }
            else
            {
                Debug.LogError("Document does not exist!");
            }
        });
    }
}
