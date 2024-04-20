using UnityEngine;

public class Aidkit : MonoBehaviour
{
    public float HealAmount = 50;
    public GameObject AidkitModel;
    public GameObject Particle;
    public AudioSource Healing;
    private void Update()
    {
        transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y + 80 * Time.deltaTime, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        var playerHealth = other.gameObject.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.AddHealth(HealAmount);
            Healing.Play();
            AidkitModel.SetActive(false);
            Particle.SetActive(false);
            GetComponent<SphereCollider>().enabled = false;
            Destroy(gameObject, 2);
        }
    }
}
