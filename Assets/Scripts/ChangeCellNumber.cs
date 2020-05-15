using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeCellNumber : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CellOnClick()
    {
        // klicem funkcijo iz cell button?
        CellButton c = new CellButton();
        c.ChangeCell();
    }
}
