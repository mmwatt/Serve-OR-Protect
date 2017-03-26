using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CutsceneController : MonoBehaviour {
    public GameObject o_choiceBad;
    public GameObject o_choiceGood;
    public GameObject o_mainText;
    public GameObject o_player;
    public GameObject o_otherChar;

    private Button choiceBad;
    private Button choiceGood;
    private Text mainText;
    private Image player;
    private Image otherChar;

    private int currentStep = 0;
    private void Start () {
        choiceBad = o_choiceBad.GetComponent<Button>();
        choiceGood = o_choiceGood.GetComponent<Button>();
        mainText = o_mainText.GetComponent<Text>();
        //player = o_player.GetComponent<Image>();
        //otherChar = o_otherChar.GetComponent<Image>();

        o_player.SetActive(false);
        o_otherChar.SetActive(false);
    }

    private void displayText (string text, bool mainCharSpeaking) {
        mainText.text = text;
        if (mainCharSpeaking) {
            //player.enabled = true;
            //otherChar.enabled = false;
        } else {
            //player.enabled = false;
            //otherChar.enabled = true;
        }
    }

    private void changeButtonText(Button button, string text) {
        button.gameObject.SetActive(true);
        button.GetComponent<Text>().text = text;
    }

    public void nextText () {
        switch (currentStep) {
            case 0: //text changes etc. go here
                break;
        }
    }
    public void setChoice1 () {
        playerChoice pChoice = GameObject.FindGameObjectWithTag("playerChoice").GetComponent<playerChoice>();
        pChoice.choices[0] = true;
        LoadNextLevel();
    }
    public void setChoice2 () {
        playerChoice pChoice = GameObject.FindGameObjectWithTag("playerChoice").GetComponent<playerChoice>();
        pChoice.choices[1] = true;
        LoadNextLevel();
    }
    public void setChoice3 () {
        playerChoice pChoice = GameObject.FindGameObjectWithTag("playerChoice").GetComponent<playerChoice>();
        pChoice.choices[2] = true;
        LoadNextLevel();
    }
    public void LoadNextLevel () {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void quitApp () {
        Application.Quit();
    }

}
