using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonControllernext : MonoBehaviour
{
    public string scenename;

    public void LoadScene()
    {
        int num;
        scenename = PlayerPrefs.GetString("Scene");
        int.TryParse(scenename, out num);
        num += 1;
        scenename = num.ToString();

        SceneManager.LoadScene(scenename);
    }
}