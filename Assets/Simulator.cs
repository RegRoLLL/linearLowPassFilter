using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simulator : MonoBehaviour
{
    [SerializeField] Transform resultCursor;
    [SerializeField] float t;

    Vector2 lastPos, resultInitialPos;

    void Start()
    {
        lastPos = Vector2.zero;
        resultInitialPos = resultCursor.position;
    }

    public void Execute(Vector2 referencePos)
    {
        var vec = referencePos;

        var x = LinearLowPassFilter.Filter(vec.x, lastPos.x, t);
        var y = LinearLowPassFilter.Filter(vec.y, lastPos.y, t);

        lastPos = new Vector2(x, y);
        resultCursor.position = lastPos + resultInitialPos;
    }

    public void Reset()
    {
        lastPos = Vector2.zero;
        resultCursor.position = resultInitialPos;
    }
}
