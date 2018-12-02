using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fogRemove : MonoBehaviour
{
    public float fadeOutSpeed;

    private bool entered = false;
    private SpriteRenderer rend;

    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(!rend)
            return;
        
        if (entered)
        {
            Color actualColor = rend.color;
            actualColor.a -= fadeOutSpeed * Time.deltaTime;

            if (actualColor.a <= 0)
            {
                actualColor.a = 0;
                Destroy(gameObject);
            }
            rend.color = actualColor;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        entered = true;
    }
}