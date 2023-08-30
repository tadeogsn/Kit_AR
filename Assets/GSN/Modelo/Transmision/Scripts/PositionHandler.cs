using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct TransformBetweenPoints // could not find an appropriate name....
{
    [SerializeField]
    private Vector3 positionA;
    [SerializeField]
    private Vector3 positionB;
    [SerializeField]
    private Transform transform;

    public void SetPosition(float t)
    {
        if (transform != null)
            transform.localPosition = Vector3.Lerp(positionA, positionB, t);
    }

#if UNITY_EDITOR
    [SerializeField]
    private Color pointsColor;
    public void DrawGizmos()
    {
        Color gizmosColor = Gizmos.color;
        if (pointsColor.a <= Mathf.Epsilon) pointsColor.a = 1;

        if (transform != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(transform.localPosition, Vector3.right);
            Gizmos.color = Color.green;
            Gizmos.DrawRay(transform.localPosition, Vector3.up);
            Gizmos.color = Color.blue;
            Gizmos.DrawRay(transform.localPosition, Vector3.forward);
            Gizmos.color = pointsColor;
            Gizmos.DrawWireSphere(transform.localPosition, 0.2f);
        }

        Gizmos.color = pointsColor;
        Gizmos.DrawLine(positionA - Vector3.right, positionA + Vector3.right);
        Gizmos.DrawLine(positionB - Vector3.right, positionB + Vector3.right);
        Gizmos.DrawLine(positionA - Vector3.up, positionA + Vector3.up);
        Gizmos.DrawLine(positionB - Vector3.up, positionB + Vector3.up);
        Gizmos.DrawLine(positionA - Vector3.forward, positionA + Vector3.forward);
        Gizmos.DrawLine(positionB - Vector3.forward, positionB + Vector3.forward);
        Gizmos.color = gizmosColor;
    }
#endif
}

public class PositionHandler : MonoBehaviour
{
    [SerializeField]
    private TransformBetweenPoints[] transforms;

    public void SetPosition(float value)
    {
        for (int i = 0; i < transforms.Length; ++i)
            transforms[i].SetPosition(value);
    }

#if UNITY_EDITOR
    public void OnDrawGizmosSelected()
    {
        for (int i = 0; transforms != null && i < transforms.Length; ++i)
            transforms[i].DrawGizmos();
    }
#endif
}