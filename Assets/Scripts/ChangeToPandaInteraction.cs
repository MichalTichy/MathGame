using UnityEngine;

class ChangeToPandaInteraction : CharacterTextBubbleInteraction
{
    public SpriteRenderer Sister;
    public DialogBubble SecondDialog;
    public CharacterMovement movement;

    protected override void BubbleClosed()
    {
        base.BubbleClosed();

        Sister.sprite = Resources.Load("panda", typeof(Sprite)) as Sprite;

        new WaitForSeconds(2);

        SecondDialog.ShowBubble();


    }

    protected override TriggerMechanism TriggerMechanism => TriggerMechanism.Manual;

    void StartLate()
    {

        SecondDialog.OnClose += SecondDialogOnClose;
        StartInteraction();

    }

    private void SecondDialogOnClose()
    {
        End();
    }

    public override void AwardPlayer()
    {
        movement.enabled = true;
    }

    protected override void Setup()
    {
        
    }
}