

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InfoCovidScript : MonoBehaviour
{
    public Text myText;

    public string[] InfoCovid =
    {

};

    void Start()
    {
        string myString = InfoCovid[Random.Range(0, InfoCovid.Length)];
        myText.text = myString;
    }
}

