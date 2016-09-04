using UnityEngine;

public class KeyboardInput : MonoBehaviour
{
    public Player Player;

    public void Update()
    {
        var needmove = false;
        var forward = false;
        var idir = new Vector2();
        if (Input.GetKey(KeyCode.W))
        {
            forward = true;
            idir.y = 1;
            needmove = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            idir.y = -1;
            forward = false;
            needmove = true;
        }
        if (Input.GetKey(KeyCode.A))
        {
            idir.x = -1;
            forward = false;
            needmove = true;
        }

        if (Input.GetKey(KeyCode.D))
        {
            idir.x = 1;
            forward = false;
            needmove = true;
        }

        var fordir = Player.transform.forward;
        fordir.y = 0;
        var rightdir = Player.transform.right;
        rightdir.y = 0;
        if (needmove)
        {
            var dir = fordir * idir.y + rightdir * idir.x;
            Player.Move(dir, forward);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            Player.Rotate(true);
        }

        if (Input.GetKey(KeyCode.E))
        {
            Player.Rotate(false);
        }
    }
}