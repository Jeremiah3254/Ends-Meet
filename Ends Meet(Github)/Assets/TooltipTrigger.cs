using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TooltipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public string uName;
    public string uDescription;
    public int uCost;
    public bool empty;
    public int minUPG;
    public int maxUPG;

    void Awake() {
        //gameObject.GetComponent<Button>
        gameObject.GetComponent<Button>().onClick.AddListener(() => StartCoroutine(refreshDelay()));
    }

    IEnumerator refreshDelay() {
        yield return new WaitForSeconds(0.1f * Time.deltaTime);
        TooltipSystem.Show(uDescription,uName,uCost,empty,minUPG,maxUPG);
    }
    public void OnPointerEnter(PointerEventData eventData) {
        TooltipSystem.Show(uDescription,uName,uCost,empty,minUPG,maxUPG);
    }

    public void OnPointerExit(PointerEventData eventData) {
       TooltipSystem.Hide();
    }
}
