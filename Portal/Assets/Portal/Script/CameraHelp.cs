using UnityEngine;

public class CameraHelp : MonoBehaviour
{
    public Camera Target;

    private Camera m_cam;

    public void Awake()
    {
        m_cam = GetComponent<Camera>();
    }
    public void Update()
    {
        m_cam.nearClipPlane = Target.nearClipPlane;
    }
}