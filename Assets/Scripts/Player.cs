using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // components
    private Rigidbody2D rigidBody2D;
    private AudioSource audioSource;
    // child objects/components
    [SerializeField] private ParticleSystem crashEffect;
    [SerializeField] private ParticleSystem snowEffect;

    // other game objects and components
    [SerializeField] private Ground groundScript;

    // Player variables settings
    [SerializeField] private float torqueForce = 750f;
    [SerializeField] private float linearForceAdder = 5f;
    [SerializeField] private float crashReloadDelay = 0.5f;


    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        if (rigidBody2D == null ) { Debug.LogError("rigidbody2D is NULL"); }
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null) { Debug.LogError("audioSource is NULL"); }
    }

    // Update is called once per frame
    void Update()
    {
        // control rotation of snowboarder
        rigidBody2D.AddTorque(-Input.GetAxis("Vertical") * torqueForce*Time.deltaTime);

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("Player is colliding with something");
        // boost when pressing horizontal keys and when touching ground 
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Player is colliding with Ground");
            groundScript.addToBaseEffectorSpeed(linearForceAdder * Input.GetAxis("Horizontal"));
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        snowEffect.Play();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        snowEffect.Stop();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            Debug.Log("Player hit head on ground!");
            Invoke("ReloadScene", crashReloadDelay);
            crashEffect.Play();
            audioSource.Play();
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene("Level1");
    }
}
