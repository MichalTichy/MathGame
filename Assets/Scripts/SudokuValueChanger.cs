using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SudokuValueChanger : MonoBehaviour {

    public HomeworkInteraction homeworkInteraction;
    public int row;
    public int column;

    private string lastNumber= "0";

    public void ValueChanged(string value)
    {
        if (lastNumber.Equals(value))
            return;
        lastNumber = value;
        homeworkInteraction.OnValueChange(value, row, column);
    }
}
