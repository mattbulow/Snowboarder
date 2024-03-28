using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] private float crashReloadDelay = 1f;
    [SerializeField] private ParticleSystem finishEffect;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null) { Debug.LogError("audioSource is NULL"); }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("You reached the finish line!");
            finishEffect.Play();
            audioSource.Play();
            Invoke("ReloadScene", crashReloadDelay);
        }
    }
    void ReloadScene()
    {
        SceneManager.LoadScene("Level1");
    }
}