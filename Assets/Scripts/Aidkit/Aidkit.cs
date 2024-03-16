using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aidkit : MonoBehaviour
{
    public float HealAmount = 50;
    private void Update()
    {
        transform.localEulerAngles = new Vector3(0,transform.localEulerAngles.y + 80 * Time.deltaTime,0);
    }
    private void OnTriggerEnter(Collider other)
    {
        var playerHealth = other.gameObject.GetComponent<PlayerHealth>();
        if(playerHealth != null)
        {
            playerHealth.AddHealth(HealAmount);
            Destroy(gameObject);
        }
    }
}
