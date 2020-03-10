using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System;
using System.Text.RegularExpressions;

public class AnimationControllerIGV : MonoBehaviour
{    
    private GameObject activeModel = null;
    public bool loopAnim = false;
    // Start is called before the first frame update
    void Start()
    {

        UpdateAnimationList();
        activeModel.GetComponent<Animation>().wrapMode = WrapMode.Loop;
        
    }

    

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeAnimation(string animationName)
    {
        //Debug.Log("Animation To Activate: " + animationName);
        GameObject activeModel = GameObject.Find("Models").GetComponent<RotatorIGV>().GetActiveModel();
        foreach (AnimationState child in activeModel.GetComponent<Animation>())
        {
            if (child.clip.name.Equals(animationName))
            {
                activeModel.gameObject.GetComponent<Animation>().clip = child.clip;
            }
            
        }
        activeModel.gameObject.GetComponent<Animation>().Play();
    }

    public void UpdateActiveModel()
    {
        activeModel = GameObject.Find("Models").GetComponent<RotatorIGV>().GetActiveModel();
    }

    public void UpdateAnimationList()
    {
        UpdateActiveModel();       
        List<string> options = new List<string>();
        //activeModel.GetComponent<Animation>().playAutomatically = false;
        Debug.Log("Active Model: "+activeModel.name);
        activeModel.GetComponent<Animation>().wrapMode = loopAnim ? WrapMode.Loop : WrapMode.Once;
        Regex idleRegex = new Regex(@"\w+_Idle");
        string idleAnimName = "";
        foreach (AnimationState child in activeModel.GetComponent<Animation>())
        {
            options.Add(child.name);
            if (idleRegex.IsMatch(child.name))
            {
                idleAnimName = child.name;
            }
        }

        Debug.Log("IdleAnimName: " + idleAnimName);
        ChangeAnimation(idleAnimName);

    }

    public void UpdateWrapMode(bool loop)
    {
        loopAnim = loop;
        activeModel.GetComponent<Animation>().wrapMode = loop ? WrapMode.Loop : WrapMode.Once;        
        if(loop && !activeModel.GetComponent<Animation>().isPlaying)
        {
            //Debug.Log("Current Anim: " + activeModel.GetComponent<Animation>());
            activeModel.GetComponent<Animation>().Play(activeModel.GetComponent<Animation>().clip.name);
        }
    }

}
