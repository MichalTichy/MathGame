using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public abstract class CharacterInteraction : MonoBehaviour
{

    protected bool canInitialize = true;
    void OnTriggerStay2D(Collider2D other)
    {
        if (!canInitialize)
            return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            Initialize();
        }
    }


    public virtual void Initialize()
    {
        if (!ArePreConditionsMet())
            return;

        canInitialize = false;
        Setup();
    }

    public virtual void End()
    {
        if (ArePostConditionsMet())
            AwardPlayer();
        
    }

    public virtual void Cancel()
    {
    }

    public abstract void AwardPlayer();

    public virtual bool ArePostConditionsMet()
    {
        return true;
    }

    protected virtual bool ArePreConditionsMet()
    {
        return true;
    }

    protected abstract void Setup();


}


public abstract class CharacterInteractionWithSceneSwitching : CharacterInteraction
{
    public GameObject puzzle;

    public override void Initialize()
    {
        base.Initialize();
        TransferControl();
    }

    public override void End()
    {
        base.End();
        TransferControlBackToMainGame();
    }

    public override void Cancel()
    {
        base.Cancel();
        TransferControlBackToMainGame();
    }

    protected virtual void TransferControl()
    {
        canInitialize = false;
        CharacterMovement.Enabled = false;
        puzzle.SetActive(true);
    }

    protected virtual void TransferControlBackToMainGame()
    {
        canInitialize = true;
        CharacterMovement.Enabled = true;
        puzzle.SetActive(false);
    }
}

