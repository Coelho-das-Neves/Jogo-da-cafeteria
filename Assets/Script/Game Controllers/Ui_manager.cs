using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ui_manager : MonoBehaviour
{
    public Camera mainCamera;
    public int cameraDistance = 13;
    public float moveSpeed = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void VerCozinha()
    {
        Vector2.Lerp(mainCamera.transform.position, 
                        new Vector3(-cameraDistance, 
                                    mainCamera.transform.position.y, mainCamera.transform.position.z), 
                                    moveSpeed * Time.deltaTime);
    }
}
