using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public abstract class CharacterInteraction : MonoBehaviour
{


    void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Initialize();
        }
    }

    public virtual void Initialize()
    {
        if (!ArePreConditionsMet())
            return;

        Setup();

        
    }

    public virtual void End()
    {
        if (ArePostConditionsMet())
            AwardPlayer();
        
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
    public Camera SourceCamera;
    public Camera TargetCamera;

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

    protected virtual void TransferControl()
    {
        CharacterMovement.Enabled = false;
        SourceCamera.enabled = false;
        TargetCamera.enabled = true;
    }

    protected virtual void TransferControlBackToMainGame()
    {
        CharacterMovement.Enabled = true;
        TargetCamera.enabled = false;
        SourceCamera.enabled = true;
    }
}

