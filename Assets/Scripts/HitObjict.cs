using UnityEngine;
using UnityEngine.SceneManagement;

public class HitObjict : MonoBehaviour
{
    [SerializeField] float LvelDelay = 1f;
    [SerializeField] AudioClip Success;
    [SerializeField] AudioClip Explosion;
    [SerializeField] ParticleSystem ParticleSuccess;
    [SerializeField] ParticleSystem ParticleExplosion;

    AudioSource AudioS;

    bool isTransitioning = false;
    bool collisionDisable = false;
    void Start()
    {
        AudioS = GetComponent<AudioSource>();
    }

    void Update()
    {
        ResssspondToDebugKeys();
    }

    void ResssspondToDebugKeys()
    {
        if (Input.GetKeyDown(KeyCode.L))
       {
            LoadNextLvel();

        }
      else if (Input.GetKeyDown(KeyCode.C))
        {
            collisionDisable = !collisionDisable; // toggle collision
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (isTransitioning || collisionDisable) { return; }

        switch (collision.gameObject.tag)
        {
            case "Start":
                Debug.Log("Hi");
                break;
            case "Finsh":
                Debug.Log("Finsh");
                collision.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
                StartSuccessSequence();


                break;
            case "Fuel":
                Debug.Log("Fuel");

                break;
            default:

                StartCrashSequence();
                Debug.Log("Sorry Blew Up");

                break;

        }

    }

    void StartSuccessSequence()
    {
        isTransitioning = true;
        AudioS.Stop();
        AudioS.PlayOneShot(Success);
        ParticleSuccess.Play();
        GetComponent<Movment>().enabled = false;
        Invoke("LoadNextLvel", LvelDelay);
    }
    void StartCrashSequence()
    {
        //  gameObject.GetComponent<Movment>() == GetComponent<Movment>()  �� ��  ������ ����� ������ ������
        isTransitioning = true;
        AudioS.Stop();
        AudioS.PlayOneShot(Explosion);
        ParticleExplosion.Play();
        AudioS.GetComponent<AudioSource>().loop = false;
        GetComponent<Movment>().enabled = false;
        Invoke("ReloadLvel", LvelDelay);
    }
    void LoadNextLvel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneInde = currentSceneIndex + 1;
        if (nextSceneInde == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneInde = 0;
        }
        SceneManager.LoadScene(nextSceneInde);
    }
    void ReloadLvel()
    {

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        GetComponent<Movment>().enabled = true;

        //SceneManager.LoadScene("Sandbox");
        //SceneManager.LoadScene(0);
    }

}
