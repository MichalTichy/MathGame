using UnityEngine;

public abstract class CharacterInteractionWithSceneSwitching : CharacterInteraction
{
    public GameObject puzzle;
    public CharacterMovement characterMovement;
    
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
        characterMovement.enabled = false;
        characterMovement.Stop();
        puzzle.SetActive(true);
    }

    protected virtual void TransferControlBackToMainGame()
    {
        characterMovement.enabled = true;
        puzzle.SetActive(false);
    }
}