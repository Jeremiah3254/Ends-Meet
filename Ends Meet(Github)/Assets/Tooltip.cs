using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//[ExecuteInEditMode()]
public class Tooltip : MonoBehaviour
{
   public Text uName;
   public Text uDescription;
   public Text uCostText;
   public int uCost;
   //public bool empty;

   public RectTransform rectTransform;

   private void Awake() {
       rectTransform = GetComponent<RectTransform>();
   }
    public void setTooltipUText(string description,string upgradeName,int cost) {
       uName.text = upgradeName;
       uDescription.text = description;
       uCostText.text = cost.ToString();
    }

    private void Update() {
        Vector2 position = Input.mousePosition;//new Vector2(Input.mousePosition.x,Input.mousePosition.y);
        float pivotX = position.x / Screen.width;
        float pivotY = position.y / Screen.height;

        rectTransform.pivot = new Vector2(pivotX,pivotY);
        transform.position = position;
    }

}
 