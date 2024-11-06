using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float vel;
    public bool dirALaDreta;
    public bool jocComencat;

    public void CanviarDireccio()
    {
        if (!jocComencat) jocComencat = true;

        dirALaDreta = !dirALaDreta;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody> ();
    }

    void Update()
    {
        if (jocComencat)
        {
            if (dirALaDreta) rb.linearVelocity = (Vector3.right * vel) + Physics.gravity;
            else rb.linearVelocity = (Vector3.forward * vel) + Physics.gravity;
        }
    }
}
