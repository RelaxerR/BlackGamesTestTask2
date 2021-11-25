using UnityEngine;

public class Drag : MonoBehaviour
{
    public Transform Target;
    public static Drag Instance;

    private Vector3 _offset;
    private float _distance;
    private Camera _camera;

    private void Awake(){
        _camera = Camera.main;
    }
    private void Start(){
        Instance = this;
    }
    private void Update() {
        TakeCube();
    }

    private void TakeCube(){
        // get cube with mouse
        if (Input.GetMouseButtonDown(0)) {
            RaycastHit hit;
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit)) {
                Target = hit.transform;

                Target.transform.localScale *= 1.1f;
                _offset = Target.position - hit.point;
                _distance = hit.distance;
            }
        }

        // mouse movement
        if (Input.GetMouseButton(0) && !Input.GetMouseButtonDown(0) && Target != null) {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            var moveToPos = ray.origin + ray.direction * _distance;
            var moveVector = moveToPos - Target.position;

            if (moveToPos.y < 0.5) return; // idk. no way
            Target.transform.Translate(moveVector);
        }

        // end mouse movement
        if (Input.GetMouseButtonUp(0))
            LoseControl();
    }

    public void LoseControl(){
        if (Target != null) Target.transform.localScale /= 1.1f;
        Target = null;
    }
}