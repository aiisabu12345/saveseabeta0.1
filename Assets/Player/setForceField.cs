using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class setForceField : MonoBehaviour
{
    public float timeoffield = 5f;
    public Button button;
    public float cd = 10f;
    public TextMeshProUGUI cooldown;

    public void StartForceField()
    {
        cd = Playerupgradevalue.cd;
        gameObject.SetActive(true);
        button.interactable = false;
        Invoke("resetcd", cd);
        Invoke("stopForceField", timeoffield);
    }

    public void stopForceField()
    {
        gameObject.SetActive(false);
    }

    public void resetcd()
    {
        button.interactable = true;
    }
}
