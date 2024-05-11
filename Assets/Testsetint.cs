using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Testsetint : MonoBehaviour
{
    int Test = 0;
    [SerializeField] TextMeshProUGUI Text;

    // Start is called before the first frame update
    void Start()
    {
        Test = PlayerPrefs.GetInt("Test",0);

        Text.text = Test.ToString();
    }

    void OnDestroy()
    {
        PlayerPrefs.SetInt("Test", Test);
        PlayerPrefs.Save();
    }
}
