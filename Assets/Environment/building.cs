using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class building : MonoBehaviour
{
    public GameObject hotel;
    public GameObject aquarium;
    public GameObject conseil;
    // Start is called before the first frame update
    void Start()
    {
      if(Playerupgradevalue.alreadybuyhotel)
      {
          hotel.gameObject.SetActive(true);
      }

      if(Playerupgradevalue.alreadybuyaquarium)
      {
          aquarium.gameObject.SetActive(true);
      }

      if(Playerupgradevalue.alreadybuyconseil)
      {
          conseil.gameObject.SetActive(true);
      }
    }
}
