using UnityEngine;

public class MoveObjects : MonoBehaviour
{
    public GameObject objectToMoveUp; // Objek yang ingin dipindahkan ke atas
    public GameObject objectToMoveDown; // Objek yang ingin dipindahkan ke bawah
    public float verticalDistanceUp = 50f; // Jarak vertikal yang ingin dipindahkan ke atas
    public float verticalDistanceDown = -50f; // Jarak vertikal yang ingin dipindahkan ke bawah
    public float duration = 100f; // Waktu dalam detik
    public GameObject panel;
    private float elapsedTimeUp = 0f;
    private float elapsedTimeDown = 0f;
    private Vector3 initialPositionUp;
    private Vector3 initialPositionDown;
    private Vector3 targetPositionUp;
    private Vector3 targetPositionDown;
    private bool isMovingUp = false;
    private bool isMovingDown = false;

    void Start()
    {
        // Menyimpan posisi awal objek
        initialPositionUp = objectToMoveUp.transform.position;
        initialPositionDown = objectToMoveDown.transform.position;

        // Menghitung posisi target
        targetPositionUp = initialPositionUp + new Vector3(0f, verticalDistanceUp, 0f);
        targetPositionDown = initialPositionDown + new Vector3(0f, verticalDistanceDown, 0f);

        // Mulai pergerakan
        isMovingUp = true;
        isMovingDown = true;
    }

    void Update()
    {
        // Memastikan sedang dalam pergerakan ke atas
        if (isMovingUp)
        {
            // Memastikan waktu belum habis
            if (elapsedTimeUp < duration)
            {
                // Menghitung persentase waktu yang telah berlalu
                float percentCompleteUp = elapsedTimeUp / duration;

                // Menggerakkan objek ke atas sesuai dengan persentase waktu yang telah berlalu
                objectToMoveUp.transform.position = Vector3.Lerp(initialPositionUp, targetPositionUp, percentCompleteUp);

                // Meningkatkan waktu yang telah berlalu untuk pergerakan ke atas
                elapsedTimeUp += Time.deltaTime;
            }
            else
            {
                // Pergerakan ke atas selesai
                isMovingUp = false; // Berhenti dari pergerakan ke atas
            }
        }

        // Memastikan sedang dalam pergerakan ke bawah
        if (isMovingDown)
        {
            // Memastikan waktu belum habis
            if (elapsedTimeDown < duration)
            {
                // Menghitung persentase waktu yang telah berlalu
                float percentCompleteDown = elapsedTimeDown / duration;

                // Menggerakkan objek ke bawah sesuai dengan persentase waktu yang telah berlalu
                objectToMoveDown.transform.position = Vector3.Lerp(initialPositionDown, targetPositionDown, percentCompleteDown);

                // Meningkatkan waktu yang telah berlalu untuk pergerakan ke bawah
                elapsedTimeDown += Time.deltaTime;
            }
            else
            {
                // Pergerakan ke bawah selesai, tampilkan pesan "Game Over" dan aktifkan panel
                Debug.Log("Game Over");
                panel.SetActive(true);
                isMovingDown = false; // Berhenti dari pergerakan ke bawah
            }
        }
    }
}
