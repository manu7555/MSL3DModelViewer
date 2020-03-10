using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System;
using System.Text.RegularExpressions;
using System.Threading;

public class RotatorIGV : MonoBehaviour
{

    public Vector3 mPrevPos = Vector3.zero;
    public Vector3 mDeltaPos = Vector3.zero;
    public bool rotateY = true;
    private GameObject activeModel;
    private int mouseWasPressed = 0;
    private int limitFrames = 3;
    private Regex idleRegex = new Regex(@"(\w+)_Attack");
    //public bool rotateXZ = false;

    void Start()
    {
        UpdateActiveModel(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            mDeltaPos = Input.mousePosition - mPrevPos;
            if (mDeltaPos.Equals(Vector3.zero) && mouseWasPressed < limitFrames && !SceneManager.GetActiveScene().name.Equals("Model Viewer"))
            {
                mouseWasPressed++;
            } 
            else if (mDeltaPos.Equals(Vector3.zero) && mouseWasPressed == limitFrames && !SceneManager.GetActiveScene().name.Equals("Model Viewer"))
            {
                foreach (AnimationState child in activeModel.GetComponent<Animation>())
                {
                    if (idleRegex.IsMatch(child.name))
                    {
                        StartCoroutine(PlayAttackAnim(child.clip));                        
                        
                    }
                }
            }
            else
            {
                mouseWasPressed++;
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
        }
        else
        {
            mouseWasPressed = 0;
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

    private IEnumerator PlayAttackAnim(AnimationClip clip)
    {
        activeModel.GetComponent<Animation>().Play(clip.name);
        yield return new WaitForSeconds(clip.length);
        activeModel.GetComponent<Animation>().Play(idleRegex.Match(clip.name).Groups[1] + "_Idle");
        activeModel.GetComponent<Animation>().wrapMode = WrapMode.Loop;
    }

    public void changeScene(string newSceneName)
    {
        SceneManager.LoadScene(newSceneName);
    }
}

