using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetJoints : MonoBehaviour {

    Transform[] allJoints;
    GameObject target;

    public InputField x;
    public InputField y;
    public InputField z;
    public InputField angle;

            
    // Get All Joint Position in 2D Array
    void Start () {
                      
        // Get Hierarchy
        Transform[] jointList = GetComponentsInChildren<Transform>();
        allJoints = jointList;
                
        List<List<float>> positionList = new List<List<float>>();

        foreach (Transform joint in jointList)
        {
            
            float xHold = joint.localPosition.x;
            float yHold = joint.localPosition.y;
            float zHold = joint.localPosition.z;

            List<float> holder = new List<float>();
            holder.Add(xHold);
            holder.Add(yHold);
            holder.Add(zHold);

            positionList.Add(holder);
            
        }                  
    }
	
	
    public void ChangeJoint(float angle)
    {
        Vector3 axis = new Vector3(1, 0, 0);
        target.transform.Rotate(axis, angle);
        
    }
    
    public void GetJoint(string joint)
    {
        target = GameObject.Find(joint);

        // check whether value is coming in correctly
        Debug.Log(target.transform.localPosition.x);
                       
    }

    public void ChangeAngles()
    {
        Vector3 temp = new Vector3();
        temp.x = Convert.ToSingle(x.text);
        temp.y = Convert.ToSingle(y.text);
        temp.z = Convert.ToSingle(z.text);

        target.transform.Rotate(temp, Convert.ToSingle(angle.text));


    }
    

}
