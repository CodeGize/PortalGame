using UnityEngine;

/// <summary>
/// 传送点
/// </summary>
public class PortalPoint : MonoBehaviour
{
    [Header("连接目标点")]
    public Transform Point;

    public Transform Render;

    public Camera Camera;

    internal protected void Start()
    {

    }

    internal protected void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter");
        other.transform.root.rotation = other.transform.root.rotation * Point.rotation * Render.rotation;
        other.transform.root.position = Point.position - new Vector3(0, 1.5f, 0);
    }

    internal protected void Update()
    {
        var cpos = Camera.main.transform.position;
        var mt = Render.worldToLocalMatrix;
        mt = Matrix4x4.TRS(Vector3.zero, Quaternion.AngleAxis(180, Vector3.up), Vector3.one) * mt;
        Camera.transform.localPosition = mt.MultiplyPoint(cpos);
        Camera.transform.LookAt(Point);
        //Camera.transform.rotation = Camera.main.transform.rotation * Point.rotation * Render.rotation;
        Camera.nearClipPlane = -Camera.transform.localPosition.z; //Vector3.Distance(transform.position, Point.position);
        const float renderHeight = 3f;
        Camera.fieldOfView = 2 * Mathf.Atan(renderHeight / 2 / Camera.nearClipPlane) * Mathf.Rad2Deg;
    }
}