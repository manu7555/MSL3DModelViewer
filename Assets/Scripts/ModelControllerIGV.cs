using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModelControllerIGV : MonoBehaviour
{
    private GameObject models;
    // Start is called before the first frame update
    void Start()
    {
        models = GameObject.Find("Models");        
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

                models.GetComponent<AnimationControllerIGV>().ChangeAnimation(model.name + "_Idle");
                
            } else
            {
                model.gameObject.SetActive(false);
            }

        }
        models.GetComponent<RotatorIGV>().UpdateActiveModel();

        models.GetComponent<AnimationControllerIGV>().UpdateActiveModel();
    }
}
