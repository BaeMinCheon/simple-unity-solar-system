using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerComponent : MonoBehaviour
{
    public float m_MoveSpeed = 0.0f;
    public float m_RotateSpeed = 0.0f;

    private void Start()
    {
        ;
    }

    private void Update()
    {
        this.TryMove();
        this.TryRotate();
    }

    private void TryMove()
    {
        if(Input.GetKey(KeyCode.W))
        {
            this.Move(this.transform.forward);
        }

        if(Input.GetKey(KeyCode.S))
        {
            this.Move(this.transform.forward * -1);
        }
    }

    private void TryRotate()
    {
        Vector2 Resolution = new Vector2(Screen.width, Screen.height);
        Vector2 ResolutionHalf = Resolution / 2.0f;
        Vector2 PositionMouse = Input.mousePosition;

        int DiffX = (int)(ResolutionHalf.x - PositionMouse.x);
        if(DiffX < -50)
        {
            this.Rotate(this.transform.up, +1.0f);
        }
        if(DiffX > +50)
        {
            this.Rotate(this.transform.up, -1.0f);
        }

        int DiffY = (int)(ResolutionHalf.y - PositionMouse.y);
        if(DiffY < -50)
        {
            this.Rotate(this.transform.right, -1.0f);
        }
        if(DiffY > +50)
        {
            this.Rotate(this.transform.right, +1.0f);
        }
    }

    private void Move(Vector3 Direction)
    {
        this.transform.Translate(Direction * this.m_MoveSpeed * Time.deltaTime);
    }

    private void Rotate(Vector3 Axis, float Value)
    {
        this.transform.rotation *= Quaternion.AngleAxis(Value * this.m_RotateSpeed * Time.deltaTime, Axis);
    }
}
