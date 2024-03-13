using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeTextStage1 : MonoBehaviour
{

    public Text buttonText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void nextDialogue()
    {
        buttonText.text = "Remember, Whiskers, when we first stumbled upon this forest? You were just a tiny ball of fur, following me around like my shadow. Now it's my turn to be your shadow and bring you back home.";
    }
}
