using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class MomMathInteraction : CharacterInteractionWithSceneSwitching
{
    protected override TriggerMechanism TriggerMechanism => TriggerMechanism.Manual;

    public DialogBubble CompletedDialog;
    public BoxCollider2D MomBoundary;

    public Text Exercise1;
    public InputField Exercise1Result;

    public Text Exercise2;
    public InputField Exercise2Result;

    public Text Exercise3;
    public InputField Exercise3Result;

    public Text Exercise4;
    public InputField Exercise4Result;

    public override void AwardPlayer()
    {
        UnityEngine.Debug.Log("Mom completed!");
        MomBoundary.enabled = false;
        CompletedDialog.ShowBubble();
    }

    protected override void Setup()
    {
        GenerateMathExercise(Exercise1);
        GenerateMathExercise(Exercise2);
        GenerateMathExercise(Exercise3);
        GenerateMathExercise(Exercise4);
    }

    public override void End()
    {
        if (ArePostConditionsMet())
        {
            base.End();
        }
    }

    public override bool ArePostConditionsMet()
    {
        var allOk = true;

        if (!IsCorrect(Exercise1.text, Exercise1Result.text))
        {
            allOk = false;
            Exercise1Result.text = "";
        }

        if (!IsCorrect(Exercise2.text, Exercise2Result.text))
        {
            allOk = false;
            Exercise2Result.text = "";
        }

        if (!IsCorrect(Exercise3.text, Exercise3Result.text))
        {
            allOk = false;
            Exercise3Result.text = "";
        }

        if (!IsCorrect(Exercise4.text, Exercise4Result.text))
        {
            allOk = false;
            Exercise4Result.text = "";
        }

        return base.ArePostConditionsMet() && allOk;
    }

    private bool IsCorrect(string math, string resultString)
    {
        int result;
        if (!int.TryParse(resultString, out result))
            return false;

        var parts = math.Split(' ');
        int n1 = Convert.ToInt32(parts.ElementAt(0));
        string op = parts.ElementAt(1);
        int n2 = Convert.ToInt32(parts.ElementAt(2));

        switch (op)
        {
            case "+": return n1 + n2 == result;
            case "-": return n1 - n2 == result;
            case "*": return n1 * n2 == result;
            case "/": return n1 / n2 == result;
            default:
                throw new IndexOutOfRangeException();
        }
    }

    private System.Random random=new System.Random();
    private ColorBlock _exercise1ResultColors;

    private void GenerateMathExercise(Text exercise)
    {
        var op = GetRandomMathOperator();

        if (op=='/')
        {
            var result = random.Next(10);
            var n2 = random.Next(1,10);
            var n1 = result * n2;
            exercise.text = $"{n1} {op} {n2} =";
        }
        else if(op=='*')
        {

            var n1 = random.Next(10);
            var n2 = random.Next(10);
            exercise.text = $"{n1} {op} {n2} =";
        }
        else
        {
            exercise.text = $"{random.Next(0, 100)} {op} {random.Next(0, 100)} =";
        }
    }

    private char GetRandomMathOperator()
    {
        switch (random.Next(4))
        {
            case 0: return '+';
            case 1: return '-';
            case 2: return '*';
            case 3: return '/';
            default:
                throw new IndexOutOfRangeException();
        }
    }
}