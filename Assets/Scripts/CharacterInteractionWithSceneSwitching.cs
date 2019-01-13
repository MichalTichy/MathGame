using UnityEngine;

public abstract class CharacterInteractionWithSceneSwitching : CharacterInteraction
{
    public GameObject puzzle;

    public override void StartInteraction()
    {
        base.StartInteraction();
        TransferControl();
    }

    public override void End()
    {
        base.End();
        TransferControlBackToMainGame();
    }

    protected virtual void TransferControl()
    {
        CharacterMovement.Enabled = false;
        puzzle.SetActive(true);
    }

    protected virtual void TransferControlBackToMainGame()
    {
        CharacterMovement.Enabled = true;
        puzzle.SetActive(false);
    }
}