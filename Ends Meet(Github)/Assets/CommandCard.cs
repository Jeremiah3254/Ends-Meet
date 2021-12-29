using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Command Card", menuName = "Command Card")]
public class CommandCard : ScriptableObject
{
    public int[] commandCardType = new int[15];
    public int[] commandCardImageID = new int[15];
    public string[] ccName = new string[15];
    [TextArea]
    public string[] ccDescription = new string[15];
    public int[] ccCosts = new int[15];
    public MonoBehaviour abilityFunctions;

}
