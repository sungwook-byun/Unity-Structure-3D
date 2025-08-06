using UnityEngine;

public class MoveRun : IMovement
{
    public float Speed;

    public MoveRun(float speed)
    {
        this.Speed = speed;
    }

    public void Move(Transform transform)
    {
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
    }
}
