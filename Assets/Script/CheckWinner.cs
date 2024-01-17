using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CheckWinner : MonoBehaviour
{
    public static CheckWinner instance;

    private void Awake()
    {
        instance = this; 
    }

public Camera defaultCamera;
public Camera WinnerCamera;
public bool isWinner = false;

public Transform target;
public float smoothSpeed = 1.0f;

// Start is called before the first frame update
void Start()
    {
    defaultCamera.enabled = true;
    WinnerCamera.enabled = false;
}

    // Update is called once per frame
    void Update()
    {
        if (isWinner)
        {
            defaultCamera.enabled = false;
            WinnerCamera.enabled = true;
        }
        
}

private void LateUpdate()
    {
    if(target != null && isWinner)
    {
        Vector3 desiredPoistion = new Vector3(target.position.x, target.position.y, target.position.z + 3.2f);
        Vector3 smoothedPosition = Vector3.Lerp(WinnerCamera.transform.position, desiredPoistion, smoothSpeed * Time.deltaTime);
            WinnerCamera.transform.position = smoothedPosition;
    }

  
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.CompareTag("Player") && playermove.instance.groundedPlayer)
        {
            isWinner = true;
        }
    }
}
