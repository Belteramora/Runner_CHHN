using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTimeScaler : MonoBehaviour
{
    public void OnSliderValueChanged(float value)
    {
        Time.timeScale = value;
    }
}
