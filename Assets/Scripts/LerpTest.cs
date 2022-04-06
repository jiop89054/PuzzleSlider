using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpTest : MonoBehaviour
{
    public Transform APosition;
    public Transform BPosition;

    public void MoveObject(float value)
    {
        this.transform.position = Vector3.Lerp(APosition.position, BPosition.position, value);
    }
}
