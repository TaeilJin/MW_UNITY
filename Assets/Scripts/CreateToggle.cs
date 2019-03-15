using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;


public class CreateToggle : MonoBehaviour {

    int[] jointIndexArray = new int[100];
    int[] jointIndexArrayFinal = new int[100];

    public GameObject sourceAvatar;
    public GameObject canvas;

    // all joints are saved here
    List<Joint> jointStructs = new List<Joint>();

    // all necessary joints are saved here
    int[] removeListFinal = new int[100];
    List<Joint> jointStructsFinal = new List<Joint>();


    void Start() {

        // extract rotation
        Transform[] sourceJointList = sourceAvatar.GetComponentsInChildren<Transform>();

        int[] removeList = new int[] { };

        int isJoint = 0;

        DefaultControls.Resources uiResources = new DefaultControls.Resources();

        foreach (Transform sourceJoint in sourceJointList)
        {

            if (removeList.Contains(isJoint))
            {

            }
            else
            {
                jointIndexArray[isJoint] = isJoint;

                float xHold = sourceJoint.localRotation.x;
                float yHold = sourceJoint.localRotation.y;
                float zHold = sourceJoint.localRotation.z;
                float wHold = sourceJoint.localRotation.w;

                string jointNameHold = sourceJoint.ToString();
                string jointName = jointNameHold.Split(' ')[0];


                Joint eachJoint = new Joint();
                {
                    eachJoint.index = isJoint;
                    eachJoint.jointName = jointName;
                    eachJoint.x = xHold;
                    eachJoint.y = yHold;
                    eachJoint.z = zHold;
                    eachJoint.w = wHold;
                }

                jointStructs.Add(eachJoint);

                Sprite uiSprite = UnityEditor.AssetDatabase.GetBuiltinExtraResource<Sprite>("UI/Skin/UISprite.psd");
                uiResources.background = uiSprite;

                Sprite checkmark = UnityEditor.AssetDatabase.GetBuiltinExtraResource<Sprite>("UI/Skin/Checkmark.psd");
                uiResources.checkmark = checkmark;

                GameObject uiToggle = DefaultControls.CreateToggle(uiResources);
                uiToggle.transform.SetParent(canvas.transform, false);

                uiToggle.GetComponentInChildren<Text>().text = eachJoint.jointName;

            }
            isJoint++;

        }
                
    }

    public void toggleChecked()
    {
        int toggleCount = 0;
        Toggle[] toggleList = canvas.GetComponentsInChildren<Toggle>();

        foreach(Toggle toggle in toggleList)
        {
            if (toggle.isOn)
            {
                
            }
            else
            {
                removeListFinal[toggleCount] = toggleCount;
                
            }
            toggleCount++;
        }

        
    }
       

    // with button call, create struct with only necessary joints
    public void constructUseJoints()
    {

        int isJoint = 0;

        foreach(Joint joint in jointStructs)
        {
            if (removeListFinal.Contains(isJoint))
            {

            }
            else
            {
                jointIndexArrayFinal[isJoint] = isJoint;

                float xHold = joint.x;
                float yHold = joint.y;
                float zHold = joint.z;
                float wHold = joint.w;


                Joint eachJoint = new Joint();
                {
                    eachJoint.index = isJoint;
                    eachJoint.jointName = joint.jointName;
                    eachJoint.x = xHold;
                    eachJoint.y = yHold;
                    eachJoint.z = zHold;
                    eachJoint.w = wHold;
                }

                jointStructsFinal.Add(eachJoint);
                
                Debug.Log(eachJoint.jointName);

            }
            isJoint++;

            
        }

                
    }

    public void chooseJointsButton()
    {
        toggleChecked();
        constructUseJoints();
        
    }


}
