using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RolledNumberScript : MonoBehaviour
{
    DiceRollScript diceRollScript;
    [SerializeField]
    TMP_Text rolledNumberText;

    void Awake()
    {
        diceRollScript = FindObjectOfType<DiceRollScript>();
    }

    void Update()
    {
        if (diceRollScript != null)
            if (diceRollScript.isLanded)
                rolledNumberText.text = diceRollScript.diceFaceNum;
            else
                rolledNumberText.text = "?";
        else
            Debug.LogError("DiceRollScript nod found in a scene!");
    }
}
