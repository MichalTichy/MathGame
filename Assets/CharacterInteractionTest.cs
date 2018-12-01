using System.Diagnostics;

public class CharacterInteractionTest : CharacterInteractionWithSceneSwitching
{

    public override void  AwardPlayer()
    {
    }

    protected override void Setup()
    {
        UnityEngine.Debug.Log("Interaction triggered");
    }
}