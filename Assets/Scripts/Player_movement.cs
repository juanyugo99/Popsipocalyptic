using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_movement : MonoBehaviour
{
    public bool start = false;
    public bool end = false;
    public float Speed = 8.0f;
    public float Rotation_Speed = 64.0f;
    public float JumpForce = 1.0f;
    public GameObject startObject;
    public GameObject endObject;
    private Rigidbody Physics;
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
        Physics = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!start && !end) {
            startObject.SetActive(true);
            endObject.SetActive(false);
            if (Input.GetKeyDown(KeyCode.Return)) {
                start = true;
            }
        }
        else if (end) {
            startObject.SetActive(false);
            endObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        else {
            startObject.SetActive(false);
            endObject.SetActive(false);
            // movimiento
            float hor = Input.GetAxis("Horizontal");
            float ver = Input.GetAxis("Vertical");

            transform.Translate(new Vector3(hor, 0.0f, ver) * Time.deltaTime * Speed);

            //rotación
            float rotationY = Input.GetAxis("Mouse X");
            
            transform.Rotate(new Vector3(0, rotationY * Time.deltaTime * Rotation_Speed, 0));

            //salto
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Physics.AddForce(new Vector3(0, JumpForce, 0), ForceMode.Impulse);
            }

            //juego termina
            if (Input.GetKeyDown(KeyCode.E)) {
                end = true;
            }
        }

    }
    public void botonInicio() {
        if (!start && !end) {
            start = true;
        }
        else if (end) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    public void botonPrueba() {
        
    }
}
