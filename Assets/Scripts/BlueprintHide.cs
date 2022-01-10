using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueprintHide : MonoBehaviour
{
    public GameObject Blueprint0, Blueprint1, Blueprint2, Blueprint3, Blueprint4;
    public GameObject BaseButton;
    public GameObject BlueprintButton;
    public GameObject VolunteerUpgrade;
    public GameObject TreeUpgrade;

    public void showPanel()
    {
        BaseButton.gameObject.SetActive(false);
        Blueprint0.gameObject.SetActive(true);
        Blueprint1.gameObject.SetActive(true);
        Blueprint2.gameObject.SetActive(true);
        Blueprint3.gameObject.SetActive(true);
        BlueprintButton.gameObject.SetActive(true);
        VolunteerUpgrade.gameObject.SetActive(true);
        TreeUpgrade.gameObject.SetActive(true);
    }

    public void hidePanel()
    {
        BaseButton.gameObject.SetActive(true);
        Blueprint0.gameObject.SetActive(false);
        Blueprint1.gameObject.SetActive(false);
        Blueprint2.gameObject.SetActive(false);
        Blueprint3.gameObject.SetActive(false);
        BlueprintButton.gameObject.SetActive(false);
        VolunteerUpgrade.gameObject.SetActive(false);
        TreeUpgrade.gameObject.SetActive(false);
    }


    
}
