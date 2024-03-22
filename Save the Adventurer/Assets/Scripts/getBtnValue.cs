using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class getBtnValue : MonoBehaviour
{
    // Referensi untuk keempat tombol yang berbeda
    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;

    // Referensi ke QuestionManager
    public QuestionManager questionManager;

    // Fungsi ini akan dipanggil ketika tombol 1 diklik
    public void OnButton1Click()
    {
        string clickedButtonText = button1.GetComponentInChildren<TextMeshProUGUI>().text;
        // Debug.Log("Nilai teks tombol 1 yang diklik: " + clickedButtonText);
        // Mengirim nilai tombol yang diklik ke QuestionManager
        questionManager.SetClickedButtonValue(clickedButtonText, 1);
    }

    // Fungsi ini akan dipanggil ketika tombol 2 diklik
    public void OnButton2Click()
    {
        string clickedButtonText = button2.GetComponentInChildren<TextMeshProUGUI>().text;
        // Debug.Log("Nilai teks tombol 2 yang diklik: " + clickedButtonText);
        // Mengirim nilai tombol yang diklik ke QuestionManager
        questionManager.SetClickedButtonValue(clickedButtonText, 2);
    }

    // Fungsi ini akan dipanggil ketika tombol 3 diklik
    public void OnButton3Click()
    {
        string clickedButtonText = button3.GetComponentInChildren<TextMeshProUGUI>().text;
        // Debug.Log("Nilai teks tombol 3 yang diklik: " + clickedButtonText);
        // Mengirim nilai tombol yang diklik ke QuestionManager
        questionManager.SetClickedButtonValue(clickedButtonText, 3);
    }

    // Fungsi ini akan dipanggil ketika tombol 4 diklik
    public void OnButton4Click()
    {
        string clickedButtonText = button4.GetComponentInChildren<TextMeshProUGUI>().text;
        // Debug.Log("Nilai teks tombol 4 yang diklik: " + clickedButtonText);
        // Mengirim nilai tombol yang diklik ke QuestionManager
        questionManager.SetClickedButtonValue(clickedButtonText, 4);
    }
}
