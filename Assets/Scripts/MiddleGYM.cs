using UnityEngine;

public class MiddleGYM : MonoBehaviour
{
    [Range(0f, 1f)]
    public float Value;

    public Transform Cube1;
    public Transform Cube2;

    public Material materialCube1;
    public Material materialCube2;
    public Material materialCube3;
    void Update()
    {
        transform.position = Vector3.Lerp(Cube1.position,Cube2.position,Value);
        transform.localScale = Vector3.Lerp(Cube1.localScale,Cube2.localScale,Value);
        materialCube3.color = Color.Lerp(materialCube1.color, materialCube2.color, Value);
    }
}
