using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public float LifeTime;
    public float Speed;
    private void Start()
    {
        Invoke("DestroyFireBall", LifeTime);
    }
    void FixedUpdate()
    {
        MoveFixedUpdate();
    }
    private void OnCollisionEnter(Collision collision)
    {
        DestroyFireBall();
    }
    void MoveFixedUpdate()
    {
        transform.position += transform.forward * Speed * Time.fixedDeltaTime;
    }
    private void DestroyFireBall()
    {
        Destroy(gameObject);
    }
}
