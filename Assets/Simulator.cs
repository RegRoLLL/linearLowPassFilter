using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XCharts.Runtime;

public class Simulator : MonoBehaviour
{
    [SerializeField] Transform resultCursor;
    [SerializeField] float t;
    [SerializeField] LineChart chartX, chartY, chartT;

    Vector2 lastPos, resultInitialPos;
    float time;

    void Start()
    {
        lastPos = Vector2.zero;
        resultInitialPos = resultCursor.position;
        chartX.ClearData();
        chartY.ClearData();
        chartT.ClearData();
        Reset();

        Time.timeScale = 5f;
    }

    public void Execute(Vector2 referencePos)
    {
        chartX.AddData(0, time, referencePos.x);
        chartY.AddData(0, time, referencePos.y);

        var vec = referencePos;

        var x = LinearLowPassFilter.Filter(vec.x, lastPos.x, t);
        var y = LinearLowPassFilter.Filter(vec.y, lastPos.y, t);

        lastPos = new Vector2(x, y);
        resultCursor.position = lastPos + resultInitialPos;

        chartX.AddData(1, time, lastPos.x);
        chartY.AddData(1, time, lastPos.y);
        chartT.AddData(0, time, t);

        time += Time.deltaTime;
    }

    public void Reset()
    {
        lastPos = Vector2.zero;
        resultCursor.position = resultInitialPos;
    }
}
