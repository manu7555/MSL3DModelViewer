using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownController : MonoBehaviour
{
    public GameObject models;
    public Dropdown dropdown;
    // Start is called before the first frame update
    void Start()
    {
        int currValue = 0;
        int count = 0;
        dropdown = GetComponent<Dropdown>();
        dropdown.ClearOptions();
        models = GameObject.Find("Models");
        List<string> options = new List<string>();
        foreach(Transform child in models.transform)
        {
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
            ChangeModel(dropdown.itemText.ToString());
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeModel(string modelName)
    {
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
    }
}
