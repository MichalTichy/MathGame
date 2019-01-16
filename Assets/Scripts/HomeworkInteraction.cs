using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class HomeworkInteraction : CharacterInteractionWithSceneSwitching
{
    [Header("Award")]
    public Stairs stairs;

    public DialogBubble GoUpBubble;


    [Header("Setup")]
    public Transform gridUI;


    private int[,] grid = new int[4, 4] { { 0, 3, 0, 4 },
                                            { 2, 0, 0, 0 },
                                            { 0, 0, 0, 1 },
                                            { 3, 0, 4, 0 },
                                            };

    public override void AwardPlayer()
    {
        UnityEngine.Debug.Log("Homework completed!");
        stairs.AllowUp = true;
        GoUpBubble.ShowBubble();
    }

    protected override void Setup()
    {
        for (int i = 0; i < gridUI.childCount; i++)
        {
            string value = grid[i / 4, i % 4].ToString();
            if (value.Equals("0"))
                continue;
            InputField input = gridUI.GetChild(i).GetComponent<InputField>();
            input.text = value;
            input.readOnly = true;
        }
    }

    public void OnValueChange(string value, int row, int column)
    {
        switch (value)
        {
            case "1":
            case "2":
            case "3":
            case "4":
                grid[row, column] = int.Parse(value);
                break;
            default:
                grid[row, column] = 0;
                break;
        }
        if (Validate())
            End();
    }

    private bool Validate()
    {
        if (!validateRows())
            return false;
        if (!validateColumns())
            return false;
        if (!validateCells())
            return false;
        return true;
    }

    private bool validateRows()
    {
        int[] row = new int[grid.GetLength(1)];
        for (int i = 0; i < grid.GetLength(0); i++)
        {
            for(int j = 0; j < grid.GetLength(1); j++)
            {
                if (grid[i, j] == 0)
                    return false;
                row[j] = grid[i, j];
            }
            if (IsRepeating(row))
                return false;
        }
        return true;
    }

    public override bool ArePostConditionsMet()
    {
        return Validate();
    }

    private bool validateColumns()
    {
        int[] column = new int[grid.GetLength(0)];
        for(int i = 0; i < grid.GetLength(1); i++)
        {
            for (int j = 0; j < grid.GetLength(0); j++)
            {
                if (grid[j, i] == 0)
                    return false;
                column[j] = grid[j, i];
            }
            if (IsRepeating(column))
                return false;
        }
        return true;
    }

    private bool validateCells()
    {
        int[] cell = new int[4];
        for(int i = 0; i < 4; i+=2)
        {
            for(int j = 0; j < 4; j++)
            {
                cell[j % 2] = grid[i, j];
                cell[j % 2 + 2] = grid[i + 1, j];
            }
            if (IsRepeating(cell))
                return false;
        }
        return true;
    }

    private bool IsRepeating(int[] a)
    {
        return a.Where(i => i == 0).GroupBy(i => i).Any(gp => gp.Count() > 1);
    }
}