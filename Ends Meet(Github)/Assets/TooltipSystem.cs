using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipSystem : MonoBehaviour
{
   private static TooltipSystem current;
   public GameObject tooltip;

   public void Awake() {
       current = this;
   }

   public static void Show(string upgradeDescription, string upgradeName, int cost,bool empty) {
       if (empty == false) {
            //current.tooltip.setTooltipUText(upgradeDescription,upgradeName);
            current.tooltip.GetComponent<Tooltip>().setTooltipUText(upgradeDescription,upgradeName,cost);
            current.tooltip.gameObject.SetActive(true);
            if (cost == 0) {
                current.tooltip.transform.Find("CurrencyDisplay").gameObject.SetActive(false);
            }else {
                current.tooltip.transform.Find("CurrencyDisplay").gameObject.SetActive(true);
            }
       }
   }

    public static void Hide() {
        current.tooltip.gameObject.SetActive(false);
    }
}
