using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalChangeInteraction : CharacterTextBubbleInteraction
{
    public DialogBubble SecondDialog;
    public CharacterMovement movement;
    public Fading fading;
    public Camera cam;
    
    [Header("Sister stuffs")]
    public SpriteRenderer Sister;
    public ParticleSystem particles;
    public DialogBubble thirdDialog;

    private float cameraZoomOutSpeed;

    public override void AwardPlayer()
    {
        SceneManager.LoadScene("Credits");
    }

    protected override void Setup()
    {
        movement.enabled = false;
        movement.Stop();
        Wait(2,() =>movement.GoToPositionOnX(50, 5));
    }

    private IEnumerator ZoomOutCamera()
    {
        while(cam.orthographicSize < 7)
        {
            cam.orthographicSize += cameraZoomOutSpeed;
            yield return null;
        }
    }

    private void Update()
    {
        cameraZoomOutSpeed = Time.deltaTime;
    }

    public override void StartInteraction()
    {
        Wait(1, () =>
        {
            StartCoroutine(ZoomOutCamera());
            base.StartInteraction();


            Wait(4, () =>
            {
                SecondDialog.ShowBubble();
                Wait(0.7f, () =>
                {
                    particles.Play();
                    Wait(0.3f, () => Sister.sprite = Resources.Load("sister", typeof(Sprite)) as Sprite);

                    Wait(1, () => thirdDialog.ShowBubble());

                    Wait(3, () => fading.FadeOut());
                    

                    Wait(5, End); //TODO HACK});
                });
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
   

    protected override TriggerMechanism TriggerMechanism => TriggerMechanism.Manual;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        StartInteraction();
    }
}
