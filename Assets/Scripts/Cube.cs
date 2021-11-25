using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private float Force;
    private Rigidbody _rigitBody;

    private void Start(){
        _rigitBody = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (transform.position.y < -10){
            transform.position = new Vector3(0, 3, 0);
        }
    }

    public void BackForce(){
        float xForce = 0;
        if (_rigitBody.velocity.x > 0) xForce = -Force;
        else xForce = Force;
        
        _rigitBody.AddForce(new Vector3(xForce, 0, 0));

        Drag.Instance.LoseControl();
    }

    public void Get(){
        GetComponentInParent<CubesController>().AddGettedCube();
        Destroy(gameObject);
    }
}