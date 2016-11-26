using UnityEngine;
using System.Collections;

public class UnityChanPoseScript : MonoBehaviour {
    Animator animator;

    int pose;
    void Awake()
    {
        animator = GetComponent<Animator>();
        ChangePose(PlayerPrefManager.GetPose());
    }
	
    void OnDisable()
    {
        PlayerPrefManager.SetPose(pose);
    }

    public void ChangePose(int i)
    {
        pose = i;
        animator.SetInteger("Pose", pose);
    }
}
