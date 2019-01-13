public abstract class CharacterTextBubbleInteraction : CharacterInteraction
{
    public DialogBubble DialogBubble;
    public bool CanTalk = true;
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

    protected override bool ArePreConditionsMet()
    {
        return base.ArePreConditionsMet() && CanTalk;
    }

    public override void ChangeInteractionState(bool enabled)
    {
        CanTalk = enabled;
        base.ChangeInteractionState(enabled);
    }
}