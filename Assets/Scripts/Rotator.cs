using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System;
using System.Text.RegularExpressions;

public class Rotator : MonoBehaviour
{

    public Vector3 mPrevPos = Vector3.zero;
    public Vector3 mDeltaPos = Vector3.zero;
    public bool rotateY = true;
    private GameObject activeModel;
    //public bool rotateXZ = false;

    void Start()
    {
        UpdateActiveModel(false);
#pragma warning disable CS0618 // Type or member is obsolete
        Application.ExternalEval("OnAppReady()");
#pragma warning restore CS0618 // Type or member is obsolete
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            mDeltaPos = Input.mousePosition - mPrevPos;
                if (rotateY)
                {
                    activeModel.transform.Rotate(transform.up, Vector3.Dot(mDeltaPos, Camera.main.transform.right), Space.World);
                }
                /*
                if (rotateXZ)
                {
                    transform.Rotate(Camera.main.transform.right, Vector3.Dot(mDeltaPos, Camera.main.transform.up), Space.World);
                }
                */
            
        }

        mPrevPos = Input.mousePosition;
    }


    public void UpdateActiveModel(bool updateAnimations = true)
    {
        foreach (Transform child in transform)
        {
            if (child.gameObject.activeSelf)
            {
                activeModel = child.gameObject;
            }
        }
        if(updateAnimations)
            GameObject.Find("AnimationList").GetComponent<AnimationDropdownController>().UpdateAnimationList();
        
    }

    public GameObject GetActiveModel()
    {
        return activeModel;
    }

    public void changeScene(string newSceneName)
    {
        /*for(int i = 0; i < SceneManager.sceneCount; i++){
            SceneManager.GetSceneAt(i).
        }*/
        SceneManager.LoadScene(newSceneName);
    }
}

