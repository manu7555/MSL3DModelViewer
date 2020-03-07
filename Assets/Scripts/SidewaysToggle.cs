using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SidewaysToggle : MonoBehaviour
{
    private Toggle sideToggle;
    public GameObject model;
    // Start is called before the first frame update
    void Start()
    {
        sideToggle = GetComponent<Toggle>();
        sideToggle.onValueChanged.AddListener(delegate
        {
            ToggleRotateYModel(sideToggle);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ToggleRotateYModel(Toggle change)
    {
        model.GetComponent<Rotator>().rotateY = change.isOn;   
    }
}
