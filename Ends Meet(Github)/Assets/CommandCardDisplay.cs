using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[HelpURL("https://docs.google.com/spreadsheets/d/1knAsXaUlot1VMU7SI1vdu7wnUkQrw_rbwXQ73LraDBQ/edit?usp=sharing")]
public class CommandCardDisplay : MonoBehaviour
{
    [Header("don't touch")]
    public GameObject[] abilityButtons;
    public Button[] buttonManagement;
    public Image[] abilityBackgrounds;
    public Image[] abilityIcons;
    [Header("These can be updated")]

    public Sprite[] ccIcons;

    public CardTemplate[] commandCards;
    public int currentLayer = 0; 

    // [0]-No Object  [1]-UpgradeButton  [2]-AbilityButton  [3]-PassiveIcon  [4]-LayerButton

    void Awake() {
        buttonManagement[0].onClick.AddListener(() => buttonClickedController(0));
        buttonManagement[1].onClick.AddListener(() => buttonClickedController(1));
        buttonManagement[2].onClick.AddListener(() => buttonClickedController(2));
        buttonManagement[3].onClick.AddListener(() => buttonClickedController(3));
        buttonManagement[4].onClick.AddListener(() => buttonClickedController(4));
        buttonManagement[5].onClick.AddListener(() => buttonClickedController(5));
        buttonManagement[6].onClick.AddListener(() => buttonClickedController(6));
        buttonManagement[7].onClick.AddListener(() => buttonClickedController(7));
        buttonManagement[8].onClick.AddListener(() => buttonClickedController(8));
        buttonManagement[9].onClick.AddListener(() => buttonClickedController(9));
        buttonManagement[10].onClick.AddListener(() => buttonClickedController(10));
        buttonManagement[11].onClick.AddListener(() => buttonClickedController(11));
        buttonManagement[12].onClick.AddListener(() => buttonClickedController(12));
        buttonManagement[13].onClick.AddListener(() => buttonClickedController(13));
        buttonManagement[14].onClick.AddListener(() => buttonClickedController(14));
        //buttonManagement[15].onClick.AddListener(() => buttonClickedController(15));
        /*for (int q = 0; q<buttonManagement.Length; q++) {
            buttonManagement[q].onClick.AddListener(() => buttonClickedController(q));
        }*/
    }

    void Update() {
        updateCCDisplay();
    }

    void buttonClickedController(int buttonID) {
        //Debug.Log("Test "+buttonID);
        if (commandCards[StateNameController.characterSelected].commandCards[currentLayer].commandCardType[buttonID] != 0 || commandCards[StateNameController.characterSelected].commandCards[currentLayer].commandCardType[buttonID] != 3) {
            //commandCards[StateNameController.characterSelected].commandCards[currentLayer].buttonFunctionality[buttonID].MainFunction();
        }
    }
    public void updateCCDisplay() {
        Debug.Log(StateNameController.characterSelected);
        for (int i = 0; i<commandCards[StateNameController.characterSelected].commandCards[currentLayer].commandCardType.Length; i++) {
            if (commandCards[StateNameController.characterSelected].commandCards[currentLayer].commandCardType[i] != 0) {
                //Debug.Log(commandCards[StateNameController.characterSelected].commandCards[currentLayer].commandCardImageID[i]);
                abilityBackgrounds[i].sprite = ccIcons[commandCards[StateNameController.characterSelected].commandCards[currentLayer].commandCardImageID[i]];
                abilityIcons[i].sprite = ccIcons[commandCards[StateNameController.characterSelected].commandCards[currentLayer].commandCardImageID[i]];
                abilityButtons[i].GetComponent<TooltipTrigger>().uName = commandCards[StateNameController.characterSelected].commandCards[currentLayer].ccName[i];
                abilityButtons[i].GetComponent<TooltipTrigger>().uDescription = commandCards[StateNameController.characterSelected].commandCards[currentLayer].ccDescription[i];
                abilityButtons[i].GetComponent<TooltipTrigger>().uCost = commandCards[StateNameController.characterSelected].commandCards[currentLayer].ccCosts[i];
                abilityButtons[i].GetComponent<TooltipTrigger>().empty = false;
                //Debug.Log("kindaWorked??");
            } else {
                resetVariables(i);
            }
        }
    }

    public void resetVariables(int indexID) {
        abilityBackgrounds[indexID].sprite = ccIcons[0];
        abilityIcons[indexID].sprite = ccIcons[0];
        abilityButtons[indexID].GetComponent<TooltipTrigger>().uName = "";
        abilityButtons[indexID].GetComponent<TooltipTrigger>().uDescription = "";
        abilityButtons[indexID].GetComponent<TooltipTrigger>().uCost = 0;
        abilityButtons[indexID].GetComponent<TooltipTrigger>().empty = true;

    }
}
