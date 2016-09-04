using UnityEngine;

/// <summary>
/// 玩家
/// </summary>
public class Player : MonoBehaviour
{
    #region 移动相关

    /// <summary>
    /// 移动速率
    /// </summary>
    [Header("移动速率,m/s")]
    public float MoveSpeed = 5;
    public float RotateSpeed = 10;

    /// <summary>
    /// 向指定方向移动
    /// </summary>
    /// <param name="dir"></param>
    /// <param name="isforward"></param>
    public void Move(Vector3 dir, bool isforward)
    {
        transform.position += dir.normalized * Time.deltaTime * MoveSpeed;
    }

    public void Rotate(bool isleft)
    {
        transform.Rotate(Vector3.up, RotateSpeed * Time.deltaTime * (isleft ? -1 : 1));
    }
    #endregion
}