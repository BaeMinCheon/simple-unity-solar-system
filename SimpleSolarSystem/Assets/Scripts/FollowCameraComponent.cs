using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCameraComponent : MonoBehaviour
{
    public Transform m_Target = null;
    public float m_Damp_Movement = 0.0f;
    public float m_Damp_Rotation = 0.0f;

    private Vector3 m_Offset = Vector3.zero;

    void Start()
    {
        this.m_Offset = this.transform.position - this.m_Target.position;
    }

    void Update()
    {
        this.FollowMovement();
        this.FollowRotation();
    }

    private void FollowMovement()
    {
        Vector3 PositionCurrent = this.transform.position;
        Vector3 PositionTarget = this.m_Target.position + (this.m_Target.rotation * this.m_Offset);
        Vector3 PositionInterpolate = Vector3.Slerp(PositionCurrent, PositionTarget, Time.deltaTime * this.m_Damp_Movement);

        this.transform.position = PositionInterpolate;
    }

    private void FollowRotation()
    {
        Quaternion RotationCurrent = this.transform.rotation;
        Quaternion RotationTarget = Quaternion.LookRotation(this.m_Target.position - this.transform.position, this.m_Target.up);
        Quaternion RotationInterpolate = Quaternion.Slerp(RotationCurrent, RotationTarget, Time.deltaTime * this.m_Damp_Rotation);

        this.transform.rotation = RotationInterpolate;
    }
}
