using UnityEngine;

public class MoveWalk : IMovement
{
    public float Speed;

    public MoveWalk(float speed)
    {
        this.Speed = speed;
    }

    public void Move(Transform transform)
    {
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
    }
}
