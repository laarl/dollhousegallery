using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CursorLookToggle: MonoBehaviour
{
    public static bool CursorEnabled = true;
    public Toggle CursorToggle;

    private void Update()
    {
        CursorEnabled = CursorToggle.isOn;
    }

}
