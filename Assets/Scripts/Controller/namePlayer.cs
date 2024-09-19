using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class namePlayer : MonoBehaviour
{
    public Text text1;
    public Text text2;

    // Update is called once per frame
    void Update()
    {
        text1.text = text2.text;
    }
}
