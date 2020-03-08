using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoopAnimToggle : MonoBehaviour
{
    private Toggle loopAnimToggle;
    private GameObject animList;
    // Start is called before the first frame update
    void Start()
    {
        animList = GameObject.Find("AnimationList");
        loopAnimToggle = GetComponent<Toggle>();
        loopAnimToggle.onValueChanged.AddListener(delegate
        {
            ToggleLoopAnim(loopAnimToggle);
        });
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ToggleLoopAnim(Toggle change)
    {
        animList.GetComponent<AnimationDropdownController>().UpdateWrapMode(change.isOn);
        
    }
}
