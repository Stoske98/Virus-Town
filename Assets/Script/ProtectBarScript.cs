using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProtectBarScript : MonoBehaviour
{
    public Slider slider;
    // Start is called before the first frame update
    public void SetProtect(float protect)
    {
        slider.value = protect;
    }

    public void SetMaxProtect(float protect)
    {
        slider.maxValue = protect;
        slider.value = protect;
    }
}
