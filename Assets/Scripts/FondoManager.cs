using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FondoManager : MonoBehaviour
{
    
    public void ActivaCasa()
    {
        transform.GetChild(1).gameObject.SetActive(true);
    }

    public void ActivaTurbio()
    {
        transform.GetChild(2).gameObject.SetActive(true);
    }

    public void ActivaBonito()
    {
        transform.GetChild(3).gameObject.SetActive(true);
    }
}
