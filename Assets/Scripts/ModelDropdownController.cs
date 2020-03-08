using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModelDropdownController : MonoBehaviour
{
    private GameObject models;
    private Dropdown dropdown;
    private Dropdown animationDropdown;
    // Start is called before the first frame update
    void Start()
    {
        animationDropdown = GameObject.Find("AnimationList").GetComponent<Dropdown>();
        models = GameObject.Find("Models");
        int currValue = 0;
        int count = 0;
        dropdown = GetComponent<Dropdown>();
        dropdown.ClearOptions();
        models = GameObject.Find("Models");
        List<string> options = new List<string>();
        foreach(Transform child in models.transform)
        {
            child.gameObject.GetComponent<Animation>().playAutomatically = false;
            options.Add(child.gameObject.name);
            if (child.gameObject.activeSelf)
            {
                currValue = count;
            }
            count++;
        }

        dropdown.AddOptions(options);
        dropdown.value = currValue;
        dropdown.onValueChanged.AddListener(delegate
        {
            ChangeModel(dropdown.options[dropdown.value].text);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeModel(string modelName)
    {
        Debug.Log("Model To Activate: " + modelName);
        foreach(Transform model in models.transform)
        {
            if (model.gameObject.name.Equals(modelName))
            {
                model.gameObject.SetActive(true);
                
            } else
            {
                model.gameObject.SetActive(false);
            }

        }
        models.GetComponent<Rotator>().UpdateActiveModel();

        animationDropdown.GetComponent<AnimationDropdownController>().UpdateActiveModel();
    }
}
