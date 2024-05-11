using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public string scenename;
    // Start is called before the first frame update
    public void Setup()
    {
        gameObject.SetActive(true);
    }

    public void Nextstage()
    {
        SceneManager.LoadScene(scenename);
    }
}
