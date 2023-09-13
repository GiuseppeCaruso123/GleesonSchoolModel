using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Password : MonoBehaviour
{
    string Code = "171107";
    string Nr = null;
    int NrIndex = 0;
    string alpha;
    public Text UiText = null;

    public void CodeFunction(string Numbers)
    {
        NrIndex++;
        Nr = Nr + Numbers;
        UiText.text = Nr;
    }
    public void enter()
    {
        if(Nr == Code)
        {
            Debug.Log("Yes");
        }
    }
}
