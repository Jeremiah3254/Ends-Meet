using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TooltipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public string uName;
    public string uDescription;
    public int uCost;
    public bool empty;

    public void OnPointerEnter(PointerEventData eventData) {
        TooltipSystem.Show(uDescription,uName,uCost,empty);
    }

    public void OnPointerExit(PointerEventData eventData) {
       TooltipSystem.Hide();
    }
}
