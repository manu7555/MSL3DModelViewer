using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SidewaysToggle : MonoBehaviour
{
    private Toggle sideToggle;
    private GameObject models;
    // Start is called before the first frame update
    void Start()
    {
        models = GameObject.Find("Models");
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
        models.GetComponent<Rotator>().rotateY = change.isOn;
    }
}
