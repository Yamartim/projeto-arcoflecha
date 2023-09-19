using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnelScroll : MonoBehaviour
{
    public ScrollRect scrollRect;
    public Image[] images;
    public string[] textos;
    public Text textoDisplay;
    public float textoDisplayTime = 10f;

    private int currentIndex = 0;

    private void Start()
    {
        UpdateImageAndText();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            currentIndex--;
            if (currentIndex < 0)
                currentIndex = images.Length - 1;

            UpdateImageAndText();
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            currentIndex++;
            if (currentIndex >= images.Length)
                currentIndex = 0;

            UpdateImageAndText();
        }
    }

    private void UpdateImageAndText()
    {
        scrollRect.content.localPosition = new Vector2(-currentIndex * scrollRect.viewport.rect.width, 0);

        foreach (Image image in images)
        {
            image.gameObject.SetActive(false);
        }

        images[currentIndex].gameObject.SetActive(true);
        textoDisplay.text = textos[currentIndex];
        textoDisplay.gameObject.SetActive(true);
        Invoke("HideText", textoDisplayTime);
    }

    private void HideText()
    {
        textoDisplay.gameObject.SetActive(false);
    }
}