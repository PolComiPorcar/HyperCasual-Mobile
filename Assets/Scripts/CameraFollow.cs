using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform objectiu;
    private Vector3 posInicial;

    void Start()
    {
        posInicial = transform.position - objectiu.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(objectiu.position.x + posInicial.x, posInicial.y, objectiu.position.z + posInicial.z);
    }
}
