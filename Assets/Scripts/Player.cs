using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // components
    private Rigidbody2D rigidBody2D;
    // child objects/components
    [SerializeField] private ParticleSystem crashEffect;
    [SerializeField] private ParticleSystem snowEffect;

    // other game objects and components
    [SerializeField] private Ground groundScript;

    // Player variables settings
    [SerializeField] private float torqueForce = 3f;
    [SerializeField] private float linearForceAdder = 5f;
    [SerializeField] private float crashReloadDelay = 0.5f;


    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        if (rigidBody2D == null ) { Debug.LogError("rigidbody2D is NULL"); }
    }

    // Update is called once per frame
    void Update()
    {

        rigidBody2D.AddTorque(-Input.GetAxis("Vertical") * torqueForce);

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("Player is colliding with something");
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
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene("Level1");
    }
}
