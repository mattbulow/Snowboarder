using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // components
    private Rigidbody2D rigidbody2D;
    // child objects/components
    [SerializeField] private ParticleSystem crashEffect;

    // Player physics settings
    [SerializeField] private float torqueForce = 3f;
    [SerializeField] private float linearForce = 50f;

    [SerializeField] private float crashReloadDelay = 0.5f;


    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        if (rigidbody2D == null ) { Debug.LogError("rigidbody2D is NULL"); }
    }

    // Update is called once per frame
    void Update()
    {

        rigidbody2D.AddTorque(Input.GetAxis("Vertical") * torqueForce);

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("Player is colliding with something");
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Player is colliding with Ground");
            float playerAngle_rad = Mathf.Deg2Rad * this.transform.eulerAngles.z;
            rigidbody2D.AddForce(new Vector2(Mathf.Cos(playerAngle_rad), Mathf.Sin(playerAngle_rad)) * linearForce * Input.GetAxis("Horizontal"));
        }
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
