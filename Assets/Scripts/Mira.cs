using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Mira : MonoBehaviour
{
    //bool para menupausa
    private bool isActive = true;

    void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        if (isActive)
        {
            Vector2 mouseCursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mouseCursorPos;
        }
    }

    public void SetActive(bool value)
    {
        isActive = value;
        gameObject.SetActive(value);
    }
}

