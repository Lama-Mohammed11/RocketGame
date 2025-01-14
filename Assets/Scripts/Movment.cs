using UnityEngine;

public class Movment : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] float speed = 100f;
    [SerializeField] float RotatSpeed = 100f;
    [SerializeField] AudioClip MainEngine;
    [SerializeField] ParticleSystem ParticleLeft;
    [SerializeField] ParticleSystem ParticleRight;
    [SerializeField] ParticleSystem ParticleBoost;

    Rigidbody rb;
    AudioSource AudioS;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        AudioS = GetComponent<AudioSource>();

    }
    void Update()
    {


        PeocessThrust();
        PeocessRotation();


    }

    void PeocessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            StartThrusting();

        }
        else
        {
            StopThrusting();
        }

    }
    void StartThrusting()
    {
        rb.AddRelativeForce(Vector3.up * speed * Time.deltaTime);
        if (!AudioS.isPlaying)
        {
            AudioS.PlayOneShot(MainEngine);
        }
        if (!ParticleBoost.isPlaying)
        {
            ParticleBoost.Play();
        }
    }
    void StopThrusting()
    {
        AudioS.Stop();
        ParticleBoost.Stop();
    }

    void PeocessRotation()
    {
        if (Input.GetKey(KeyCode.D))
        {
            RotateLeft();
        }
        else if (Input.GetKey(KeyCode.A))
        {
            RotateRight();

        }
        else
        {
            StopRotating();
        }
    }
    void ApplyRotation(float x)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * x * Time.deltaTime);
        rb.freezeRotation = false;
    }
    void RotateLeft()
    {
        ApplyRotation(-RotatSpeed);
        if (!ParticleLeft.isPlaying)
        {
            ParticleLeft.Play();
        }
    }
    void RotateRight()
    {
        ApplyRotation(RotatSpeed);
        if (!ParticleRight.isPlaying)
        {
            ParticleRight.Play();
        }
    }
    void StopRotating()
    {
        ParticleRight.Stop();
        ParticleLeft.Stop();
    }






}
