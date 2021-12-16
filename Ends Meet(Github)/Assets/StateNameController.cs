using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateNameController : MonoBehaviour
{
    public static int characterSelected;
    public static bool readyToSpawnCharacter;
    public static int difficulty;
    public static int currentWave = 1;

    //main player stats
    public static string username = "NameNotAssigned";
    public static string Rank = "beginner";
    public static int Level = 1;
    public static int XP = 0;
    public static int maxXP = 25;
    public static int DNA = 0;
    public static int[] researchUpgrades = new int[1000];
    //main player stats
}
