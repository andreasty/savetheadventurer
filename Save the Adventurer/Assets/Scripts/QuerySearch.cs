using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Firestore;
using System;
using System.Collections.Generic;
using Firebase.Extensions;

public class FirestoreSearch : MonoBehaviour
{
    FirebaseFirestore db;
    public InputField searchInputField;
    public Text searchResultText;
    DocumentReference collectionRef;

    // Method to initialize Firestore
    void Start()
    {
        // Initialize Firestore
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
            var dependencyStatus = task.Result;
            if (dependencyStatus == Firebase.DependencyStatus.Available)
            {
                // Create Firestore instance
                db = FirebaseFirestore.DefaultInstance;
                // Set collection reference
                collectionRef = db.Collection("QuestionsBank").Document("Q0001");
            }
            else
            {
                Debug.LogError("Could not resolve all Firebase dependencies: " + dependencyStatus);
            }
        });
    }

    // Method to perform search
    public void PerformSearch()
    {
        string searchTerm = searchInputField.text;
        if (searchTerm != "")
        {
            collectionRef.GetSnapshotAsync().ContinueWithOnMainThread(task => {
                if (task.IsCompleted)
                {
                    DocumentSnapshot document = task.Result;
                    if (document.Exists)
                    {
                        // Handle your document data here
                        // For now, just display the document ID
                        string resultText = string.Format("Document ID: {0}", document.Id);
                        // Display search results
                        DisplaySearchResults(resultText);
                    }
                    else
                    {
                        Debug.Log("Document not found.");
                        DisplaySearchResults("Document not found.");
                    }
                }
                else if (task.IsFaulted)
                {
                    Debug.LogError("Error performing search: " + task.Exception);
                    DisplaySearchResults("Error performing search.");
                }
            });
        }
        else
        {
            Debug.LogError("Search term is empty.");
            DisplaySearchResults("Search term is empty.");
        }
    }

    // Method to display search results
    void DisplaySearchResults(string resultText)
    {
        searchResultText.text = resultText;
    }
}
