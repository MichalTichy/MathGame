using System;
using System.Collections;
using System.Threading;
using UnityEngine;

public class ChangeToPandaInteraction : CharacterTextBubbleInteraction
{
    public SpriteRenderer Sister;
    public DialogBubble SecondDialog;
    public CharacterMovement movement;

    protected override void BubbleClosed()
    {
        base.BubbleClosed();

        SecondDialog.ShowBubble();


    }                                                         

    protected override TriggerMechanism TriggerMechanism => TriggerMechanism.Manual;

    private void Start()
    {
        DialogBubble.OnClose += BubbleClosed;
        //SecondDialog.OnClose += () => End();

        StartInteraction();

    }

    public override void StartInteraction()
    {
        
        Wait(3, () =>
        {
            base.StartInteraction();


            Wait(1, () =>
            {
                Sister.sprite = Resources.Load("panda", typeof(Sprite)) as Sprite;
                
                Wait(2, End); //TODO HACK
            });
        });
        
    }

    public void Wait(float seconds, Action action)
    {
        StartCoroutine(_wait(seconds, action));
    }

    IEnumerator _wait(float time, Action callback)
    {
        yield return new WaitForSeconds(time);
        callback();
    }

    public override void AwardPlayer()
    {
        movement.enabled = true;
    }

    protected override void Setup()
    {
        
    }
}