using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

struct Joint
{
    public int index;
    public string jointName;
    public float x;
    public float y;
    public float z;
    public float w;
}

public class RotateJoints : MonoBehaviour {

    int[] jointIndexArray = new int[100];
    public GameObject sourceAvatar;
    public GameObject targetAvatar;
    private Quaternion quaternion;
    private Quaternion temp;
    private Quaternion hold;
    
    private void Update()
    {
        // extract rotation
        Transform[] sourceJointList = sourceAvatar.GetComponentsInChildren<Transform>();

        int[] removeList = new int[] { 1, 2, 3, 4, 6,
                                        12, 13, 17, 19, 22,
                                        23, 25, 26, 27, 47,
                                        48, 49, 50, 53, 54,
                                        55, 56, 57, 58, 78 };

        List<Joint> jointStructs = new List<Joint>();

        int isJoint = 0;

        foreach (Transform sourceJoint in sourceJointList)
        {

            // Debug.Log(joint.ToString() + "  " + count);
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
                
                Joint eachJoint = new Joint();
                {
                    eachJoint.index = isJoint;
                    eachJoint.jointName = sourceJoint.ToString();
                    eachJoint.x = xHold;
                    eachJoint.y = yHold;
                    eachJoint.z = zHold;
                    eachJoint.w = wHold;
                }

                jointStructs.Add(eachJoint);

            }
            isJoint++;
        }
                
        // apply rotations
        int count = 0;
        int structIndex = 0;

        Transform[] targetJointList = targetAvatar.GetComponentsInChildren<Transform>();

        foreach (Transform targetJoint in targetJointList)
        {

            if (jointIndexArray.Contains(count))
            {                                
                // struct
                hold = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
                hold = Change(jointStructs[structIndex].x, jointStructs[structIndex].y, jointStructs[structIndex].z, jointStructs[structIndex].w);
                targetJoint.transform.rotation = hold;
                structIndex++;                
            }
            else
            {

            }
            count++;

        }
    }

    private static Quaternion Change(float x, float y, float z, float w)
    {
        return new Quaternion(x, y, z, w);
    }


}
