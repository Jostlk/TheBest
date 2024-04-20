using UnityEngine;

public class Vulcan : MonoBehaviour
{
    public Grenade GrenadePrefab;
    public float ForceMin = 100;
    public float ForceMax = 500;
    public float DelayMin = 1;
    public float DelayMax = 3;
    private void Start()
    {
        Invoke("SpawnGrenade", Random.Range(DelayMin, DelayMax));
    }
    private void SpawnGrenade()
    {
        var grenade = Instantiate(GrenadePrefab);
        grenade.transform.position = transform.position;
        var direction = Random.onUnitSphere;
        grenade.GetComponent<Rigidbody>().AddForce(direction * Random.Range(ForceMin, ForceMax));
        Invoke("SpawnGrenade", Random.Range(DelayMin, DelayMax));
    }
}
