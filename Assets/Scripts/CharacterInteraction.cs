using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public abstract class CharacterInteraction : MonoBehaviour
{
    [Header("Character stuffs to disable")]
    public BoxCollider2D characterColider;
    public Canvas characterCanvas;

    private bool _isActive;
    
    public virtual bool IsActive
    {
        get { return _isActive; }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartInteraction();
        }
    }


    public virtual void StartInteraction()
    {
        if (!ArePreConditionsMet() || IsActive)
            return;

        _isActive = true;
        
        ChangeInteractionState(false);

        Setup();
    }

    public virtual void End()
    {
        if (ArePostConditionsMet())
        {
            AwardPlayer();
        }
        else
        {
            ChangeInteractionState(true);
        }
    }

    protected virtual void ChangeInteractionState(bool enabled)
    {
        if (characterColider!=null)
        {
            characterColider.enabled = enabled;
        }

        if (characterCanvas!=null)
        {
            characterCanvas.enabled = enabled;
        }
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

public abstract class CharacterTextBubbleInteraction : CharacterInteraction
{
    public DialogBubble DialogBubble;
    

    public override void StartInteraction()
    {
        base.StartInteraction();



        ChangeInteractionState(false);
        DialogBubble.OnClose += () =>
        {

            UnityEngine.Debug.Log("Bubble closed");
            ChangeInteractionState(true);
            
        };

        DialogBubble.ShowBubble();
    }
}


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

