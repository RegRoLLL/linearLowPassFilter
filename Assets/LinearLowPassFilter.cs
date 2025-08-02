using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LinearLowPassFilter
{
    public static float Filter(float currentInput, float lastOutput, float tau)
    {
        float result = 0;
        var ts = Time.deltaTime;

        result += Mathf.Exp(-ts/tau) * lastOutput;
        result += (1 - Mathf.Exp(-ts / tau)) * currentInput;

        return result;
    }
}
