using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public abstract class CharacterInteraction : MonoBehaviour
{
    [Header("Character stuffs to disable")]
    public BoxCollider2D characterColider;
    public Canvas characterCanvas;

    protected virtual TriggerMechanism TriggerMechanism
    {
        get
        {
            return TriggerMechanism.KeyPress;
        }
    }
    
    void OnTriggerStay2D(Collider2D other)
    {
        if (TriggerMechanism != TriggerMechanism.KeyPress)
            return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            StartInteraction();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (TriggerMechanism == TriggerMechanism.ZoneEnter)
            StartInteraction();
    }


    public virtual void StartInteraction()
    {
        if (!ArePreConditionsMet())
            return;
        
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

    public virtual void ChangeInteractionState(bool enabled)
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

public enum TriggerMechanism
{
    KeyPress,
    ZoneEnter,
    Manual
}