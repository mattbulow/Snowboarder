using UnityEngine;

public class Clouds : MonoBehaviour
{
    private float initCloudPosRelToCamera;
    [SerializeField] private float speed = 0.05f;

    private void Start()
    {
        initCloudPosRelToCamera = transform.position.x - Camera.main.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        // move the clouds based proportionally on camera x-pos
        float cameraXPos = transform.position.x - Camera.main.transform.position.x - initCloudPosRelToCamera;
        this.transform.Translate(-cameraXPos * speed, 0, 0);
        initCloudPosRelToCamera = transform.position.x - Camera.main.transform.position.x;
    }
}
