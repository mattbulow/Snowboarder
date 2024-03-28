using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    private float effectorBaseSpeed = 8f;
    private SurfaceEffector2D effector;

    private void Start()
    {
        effector = GetComponent<SurfaceEffector2D>();
        if (effector == null ) { Debug.LogError("effector is NULL"); }
        effectorBaseSpeed = effector.speed;
    }

    public void addToBaseEffectorSpeed(float amount)
    {
        effector.speed = Mathf.Clamp(effectorBaseSpeed + amount,0,float.PositiveInfinity);
    }


}
