using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public GameObject SettingsPanel;

    public void show()
    {
        SettingsPanel.gameObject.SetActive(true);
    }
    
    public void hide()
    {
        SettingsPanel.gameObject.SetActive(false);
    }
}
