using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterStatsDisplay : MonoBehaviour
{
    public Text characterName;
    public Image weaponImageIcon;
    public Image ArmorImageIcon;

    public Text resourceDisplayText;

    [Header("Healthbar Stuff")]
    public GameObject healthBarUI;
    public Slider healthBar;
    public Text healthBarDisplayText;

    [Header("Energyhbar Stuff")]
    public GameObject energyBarUI;
    public Slider energyBar;
    public Text energyBarDisplayText;

    [Header("Image Storing")]

    public string[] characterNames;
    public Sprite[] WeaponImageIcons;
    public Sprite[] ArmorImageIcons;



    void Update() {
        resourceDisplayText.text = (StateNameController.blood).ToString();
        healthBarDisplayText.text = (StateNameController.playerCharacter.GetComponent<StatusManager>().health).ToString()+"/"+((StateNameController.playerCharacter.GetComponent<StatusManager>().maxHealth+StateNameController.healthBoost)).ToString();
        healthBar.value = setPercentages(StateNameController.playerCharacter.GetComponent<StatusManager>().health,(StateNameController.playerCharacter.GetComponent<StatusManager>().maxHealth+StateNameController.healthBoost));
        updateIcons();
        updateCharacterStatSheet();
    }

    float setPercentages(float num1,float num2) {
        return num1/num2;
    }
    void updateIcons() {
        characterName.text = characterNames[StateNameController.characterSelected];
        weaponImageIcon.sprite = WeaponImageIcons[StateNameController.characterSelected];
        ArmorImageIcon.sprite = ArmorImageIcons[StateNameController.characterSelected];
    }

    void updateCharacterStatSheet() {
        gameObject.transform.Find("Background").transform.Find("WeaponIconBorder").GetComponent<WeaponTooltipTrigger>().weaponName = fetchWeaponName();
        gameObject.transform.Find("Background").transform.Find("WeaponIconBorder").GetComponent<WeaponTooltipTrigger>().damage = (StateNameController.playerCharacter.GetComponent<PlayerMovement>().characterDamage+StateNameController.damageBoost);
        gameObject.transform.Find("Background").transform.Find("WeaponIconBorder").GetComponent<WeaponTooltipTrigger>().range = (StateNameController.playerCharacter.GetComponent<PlayerMovement>().attackRange+StateNameController.attackRangeBoost);
        gameObject.transform.Find("Background").transform.Find("WeaponIconBorder").GetComponent<WeaponTooltipTrigger>().attackSpeed = (StateNameController.playerCharacter.GetComponent<PlayerMovement>().attackSpeed/(1+(StateNameController.attackSpeedBoost/100)));
        gameObject.transform.Find("Background").transform.Find("WeaponIconBorder").GetComponent<WeaponTooltipTrigger>().targets = "Ground";
    }

    string fetchWeaponName() {
        if (StateNameController.characterSelected == 0) {
            return "Fists";
        }
        return "";
    }

}
