using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fading : MonoBehaviour {

    public GameObject canvas;
    public Image image;
    private float speed;

	// Use this for initialization
	void Start () {
        StartCoroutine(FadeInCoroutine());
	}

    private IEnumerator FadeInCoroutine()
    {
        Color tempClr = image.color;
        tempClr.a = 1;
        image.color = tempClr;
        while(image.color.a > 0)
        {
            tempClr.a -= speed;
            image.color = tempClr;
            yield return null;
        }

        canvas.SetActive(false);
    }

    // Update is called once per frame
    public void FadeOut()
    {
        canvas.SetActive(true);
        StartCoroutine(FadeOutCoroutine());
    }

    private IEnumerator FadeOutCoroutine()
    {
        Color tempClr = image.color;
        tempClr.a = 0;
        image.color = tempClr;
        while (image.color.a < 1)
        {
            tempClr.a += speed;
            image.color = tempClr;
            yield return null;
        }
    }

    void Update()
    {
        speed = Time.deltaTime;
    }
}
