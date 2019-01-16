using System;

public abstract class CharacterTextBubbleInteraction : CharacterInteraction
{
    public DialogBubble DialogBubble;
    public bool CanTalk = true;


    void Start()
    {
        DialogBubble.OnClose += BubbleClosed;
    }

    protected virtual void BubbleClosed()
    {

        CanTalk = true;
    }

    public override void StartInteraction()
    {

        if (!ArePreConditionsMet())
            return;

        base.StartInteraction();

        CanTalk = false;
        
        DialogBubble.ShowBubble();
    }

    protected override bool ArePreConditionsMet()
    {
        return base.ArePreConditionsMet() && CanTalk;
    }
}