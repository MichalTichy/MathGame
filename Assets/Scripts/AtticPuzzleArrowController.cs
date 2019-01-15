using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AtticPuzzleArrowController : MonoBehaviour
{
    public AtticInteraction awardScript;
    public int[] password = new int[3]{1,8,6};
    public Text[] textFields;
    private int[] currentCode = {0, 0, 0};

    public void Start()
    {
        UpdateText();
    }
    public void ArrowUp(int index)
    {
        if (currentCode[index] >= 9)
        {
            currentCode[index] = 0;
        }
        else
        {
            currentCode[index]++;
        }

        UpdateText();
        if(VerifyCode())
            awardScript.End();
    }

    public void ArrowDown(int index)
    {
        if (currentCode[index] <= 0)
        {
            currentCode[index] = 9;
        }
        else
        {
            currentCode[index]--;
        }

        UpdateText();
        if (VerifyCode())
            awardScript.End();
    }

    private void UpdateText()
    {
        for (int i = 0; i < textFields.Length; i++)
        {
            textFields[i].text = currentCode[i].ToString();
        }
    }

    public bool VerifyCode()
    {
        for (int i = 0; i < password.Length; i++)
        {
            if (password[i] != currentCode[i])
                return false;
        }

        return true;
    }
}
