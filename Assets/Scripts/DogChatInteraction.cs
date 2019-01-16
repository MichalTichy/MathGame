using System;
using System.Collections;
using UnityEngine;

public class DogChatInteraction : CharacterTextBubbleInteraction
{

    public SausageInteraction SausageInteraction;
    protected override TriggerMechanism TriggerMechanism => TriggerMechanism.ZoneEnter;


    public IShouldFeedTheDogChatInteraction AfterInteraction;
    


    public override bool Completed => AfterInteraction.Completed;
    
    public override bool ArePostConditionsMet()
    {
        return base.ArePostConditionsMet() && AfterInteraction.HasSausage;
    }

    protected override void BubbleClosed()
    {
        base.BubbleClosed();
        End();
    }

    public override void StartInteraction()
    {
       
        SausageInteraction.DogHasSpoken = true;
        base.StartInteraction();
        Wait(0.5f, () => AfterInteraction.StartInteraction());
        

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
        UnityEngine.Debug.Log("Dog completed!");
    }

    protected override void ChangeCharacterStuffStatus(bool enabled)
    {
        CanTalk = false;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        CanTalk = true;
    }



    protected override void Setup()
    {
        UnityEngine.Debug.Log("Interaction triggered");
    }
}