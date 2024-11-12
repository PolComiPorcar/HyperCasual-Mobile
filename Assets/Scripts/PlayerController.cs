using System;
using System.Net.Http.Headers;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public static PlayerController Instancia;
    public float vel;
    public bool dirALaDreta;
    public bool jocComencat;
    private bool viu = true;
    [SerializeField] private GameObject panelGameOver;


    private void OnEnable()
    {
        if (Instancia == null) Instancia = this;
    }
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
        if (jocComencat && viu)
        {
            if (dirALaDreta) rb.linearVelocity = (Vector3.right * vel) + Physics.gravity;
            else rb.linearVelocity = (Vector3.forward * vel) + Physics.gravity;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ZonaDeMort")
        {
            viu = false;
            rb.linearVelocity = Physics.gravity;
            panelGameOver.SetActive(true);
        }
    }
}
