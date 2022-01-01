using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipSystem : MonoBehaviour
{
   private static TooltipSystem current;
   public GameObject tooltip;
   public GameObject weaponTooltip;

   public void Awake() {
       current = this;
   }

    public static void showWeaponTooltip(string WeaponName, float Damage, float Range, float WeaponSpeed, string Targets) {
        current.weaponTooltip.GetComponent<WeaponTooltip>().setTooltipUText(WeaponName,Damage,Range,WeaponSpeed,Targets);
        current.weaponTooltip.gameObject.SetActive(true);
    }

    public static void hideWeaponTooltip() {
        current.weaponTooltip.gameObject.SetActive(false);
    }

   public static void Show(string upgradeDescription, string upgradeName, int cost,bool empty,int minUPG,int maxUPG) {
       if (empty == false) {
            //current.tooltip.setTooltipUText(upgradeDescription,upgradeName);
            current.tooltip.GetComponent<Tooltip>().setTooltipUText(upgradeDescription,upgradeName,cost,minUPG,maxUPG);
            current.tooltip.gameObject.SetActive(true);
            if (cost == 0) {
                current.tooltip.transform.Find("CurrencyDisplay").gameObject.SetActive(false);
            }else {
                current.tooltip.transform.Find("CurrencyDisplay").gameObject.SetActive(true);
            }
            if (maxUPG == 0) {
                current.tooltip.transform.Find("UpgradeAmount").gameObject.SetActive(false);
            }else {
                current.tooltip.transform.Find("UpgradeAmount").gameObject.SetActive(true);
            }
       }
   }

    
    public static void Hide() {
        current.tooltip.gameObject.SetActive(false);
    }
}
