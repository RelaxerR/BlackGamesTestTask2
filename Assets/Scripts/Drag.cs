using UnityEngine;

public class Drag : MonoBehaviour
{
    public Transform target;
    private Vector3 offset;
    private float distance;

    void Update() {
        TakeCube();
    }

    private void TakeCube(){
        if (Input.GetMouseButtonDown(0)) { // Захват мышью
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit)) {
                target = hit.transform;
                target.transform.localScale *= 1.5f;
                offset = target.position - hit.point;
                distance = hit.distance;
            }
        }
        if (Input.GetMouseButton(0) && !Input.GetMouseButtonDown(0) && target != null) { // Передвижение
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            target.position = ray.origin + ray.direction * distance + offset;
        }
        if (Input.GetMouseButtonUp(0)){
            if (target != null) target.transform.localScale /= 1.5f;
            target = null;
        } // Отпускание   
    }
}