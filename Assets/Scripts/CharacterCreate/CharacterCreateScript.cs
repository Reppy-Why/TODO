using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum statIndex
{
    STR = 0,
    FRT,
    DEX,    
    MAX
}

public class CharacterCreateScript : MonoBehaviour
{
    private UIController UI;
    private Character PC;

    private Dictionary<string, CharacterClass> Classes
        = new Dictionary<string, CharacterClass> ()
    {
        { CharacterClasses.Warrior.getName (), CharacterClasses.Warrior },
        { CharacterClasses.Rogue.getName (), CharacterClasses.Rogue },
        { CharacterClasses.Defender.getName (), CharacterClasses.Defender },
        { CharacterClasses.Peasant.getName (), CharacterClasses.Peasant }
    };      

    public void ClassSelectionChange ()
    {
        string ClassSelectionKey = 
            GameObject.Find ("Class Select: List")
            .GetComponent<UIPopupList> ().value.Trim ();

        CharacterClass ClassSelection = Classes [ClassSelectionKey];

        PC = GetComponent<Character> ();
        PC.setClass (ClassSelection);

        UI = GetComponent<UIController> ();
        UI.UpdateClassSelection ();

        RerollStats ();
    }

    public void PCNameChange ()
    {
        UIInput NameInput = GameObject.Find ("Name: Input")
            .GetComponent<UIInput> ();

        PC.setName (NameInput.value);
    }

    public void RerollStats ()
    {
        PC = GetComponent<Character> ();
        PC.RerollStats ();

        UI = GetComponent<UIController> ();
        UI.UpdateStatTable (PC.getStartingStats () [statIndex.STR],
                            PC.getStartingStats () [statIndex.DEX],
                            PC.getStartingStats () [statIndex.FRT]);

    }

    public void StartGame ()
    {
        return;
    }
}