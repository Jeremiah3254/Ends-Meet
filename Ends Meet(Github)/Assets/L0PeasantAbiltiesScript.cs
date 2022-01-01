using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L0PeasantAbiltiesScript : MonoBehaviour
{
    public bool[] activeAbilities = new bool[15];
    void Update()
    {
        for (int i = 0; i<activeAbilities.Length; i++) {
            if (activeAbilities[i] == true) {
                AbilityChecker(i);
            }
        }

    }

    void AbilityChecker(int index) {
        if (index == 0) {

        }else if (index == 1) {

        }else if (index == 2) {
            
        }else if (index == 3) {
            
        }else if (index == 4) {
            
        }else if (index == 5) {
            
        }else if (index == 6) {
            
        }else if (index == 7) {
            
        }else if (index == 8) {
            
        }else if (index == 9) {
            
        }else if (index == 10) {
            
        }else if (index == 11) {
            
        }else if (index == 12) {
            
        }else if (index == 13) {
            
        }else if (index == 14) {
            
        }
    }

}