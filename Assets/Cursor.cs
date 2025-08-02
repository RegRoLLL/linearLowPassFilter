using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Cursor : MonoBehaviour
{
    [SerializeField] Simulator simulator;

    bool dragging;
    Vector2 initialPos, dragStartPos;

    void Start()
    {
        initialPos = transform.position;
    }

    void Update()
    {
        if (!dragging)
        {
            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                dragging = true;
                dragStartPos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            }
            else return;
        }
        else if (Mouse.current.leftButton.wasReleasedThisFrame)
        {
            dragging = false;
            transform.position = initialPos;
            simulator.Reset();
            return;
        }

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        transform.position = mousePos - dragStartPos + initialPos;

        simulator.Execute(mousePos - dragStartPos);
    }
}
