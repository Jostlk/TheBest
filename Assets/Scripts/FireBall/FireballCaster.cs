using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballCaster : MonoBehaviour
{
    public float Damage = 10;

    public FireBall FireballPrefab;
    public Transform FireballSourceTransform;
    public AudioSource FireballSound;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var fireball = Instantiate(FireballPrefab, FireballSourceTransform.transform.position, FireballSourceTransform.transform.rotation);
            fireball.Damage = Damage;
        }
    }
}
