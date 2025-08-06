using UnityEngine;

public class MoveFly : IMovement
{
    public float Speed;

    public MoveFly(float speed)
    {
        this.Speed = speed;
    }

    public void Move(Transform transform)
    {
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
    }
}
