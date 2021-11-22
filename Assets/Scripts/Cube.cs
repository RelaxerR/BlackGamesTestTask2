using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private float Force;
    private Rigidbody rb;

    private void Start(){
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (transform.position.y < -10){
            transform.position = new Vector3(0, 3, 0);
        }
    }

    public void BackForce(){
        if (transform.position.x < 0)
            rb.AddForce(Vector3.right * Force);
        else
            rb.AddForce(Vector3.left * Force);
    }

    public void Get(){
        GetComponentInParent<CubesController>().AddGettedCube();
        Destroy(gameObject);
    }
}