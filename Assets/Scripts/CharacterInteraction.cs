using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public abstract class CharacterInteraction : MonoBehaviour
{
    [Header("Character stuffs to disable")]
    public BoxCollider2D characterColider;
    public Canvas characterCanvas;
    private bool _completed;

    protected virtual TriggerMechanism TriggerMechanism => TriggerMechanism.KeyPress;

    public virtual bool Completed =>_completed;

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
        ChangeCharacterStuffStatus(false);
        Setup();
    }

    public virtual void End()
    {
        if (ArePostConditionsMet())
        {
            AwardPlayer();
            _completed = true;
        }
        else
        {
            ChangeCharacterStuffStatus(true);
        }
    }

    protected virtual void ChangeCharacterStuffStatus(bool enabled)
    {
        if (characterColider != null)
            characterColider.enabled = enabled;

        if (characterCanvas != null)
            characterCanvas.enabled = enabled;
    }

    public abstract void AwardPlayer();

    public virtual bool ArePostConditionsMet()
    {
        return true;
    }

    protected virtual bool ArePreConditionsMet()
    {
        return !Completed;
    }

    protected abstract void Setup();


}

public class SousageInteraction : CharacterInteraction
{
    public IShouldFeedTheDogChatInteraction FeedTheDogChatInteraction;
    public DialogBubble Dialog;
    public SpriteRenderer Sousage;
    public override void AwardPlayer()
    {
        FeedTheDogChatInteraction.HasSausage = true;
        Sousage.enabled = false;
    }

    public override void StartInteraction()
    {
        if (!ArePreConditionsMet())
            return;


        Dialog.ShowBubble();
        base.StartInteraction();
        End();
    }

    protected override bool ArePreConditionsMet()
    {
        return base.ArePreConditionsMet() && FeedTheDogChatInteraction.HasSausage==false;
    }

    protected override void Setup()
    {
        
    }
}

public enum TriggerMechanism
{
    KeyPress,
    ZoneEnter,
    Manual
}