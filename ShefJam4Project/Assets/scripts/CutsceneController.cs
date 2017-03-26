using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    private void Start () {
        choiceBad = o_choiceBad.GetComponent<Button>();
        choiceGood = o_choiceGood.GetComponent<Button>();
        mainText = o_mainText.GetComponent<Text>();
        player = o_player.GetComponent<Image>();
        otherChar = o_otherChar.GetComponent<Image>();
    }
}
