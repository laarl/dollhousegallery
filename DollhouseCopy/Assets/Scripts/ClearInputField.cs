using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClearInputField : MonoBehaviour
{
    public TMP_InputField inputToClear;

    public void ClearFields()
    {
        inputToClear.text = "";
        inputToClear.DeactivateInputField();
    }


}
