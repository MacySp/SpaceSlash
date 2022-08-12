using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPopup : MonoBehaviour
{
    //public bool isActive = false;
    public GameObject self;

    public void Update()
    {
        Disable();
    }

    public void Disable()
    {
        self.SetActive(true);
    }
    public void Enable()
    {
        self.SetActive(false);
    }
}
