using UnityEngine;
using UnityEngine.UI;

public class Wall : MonoBehaviour
{
    [SerializeField] private Text CountText;

    private int _count;

    private void OnCollisionEnter(Collision col){
        if (col.gameObject.tag == gameObject.tag){
            ChangeCount();
            col.gameObject.GetComponent<Cube>().Get();
        }
        else{
            col.gameObject.GetComponent<Cube>().BackForce();
        }
    }

    private void ChangeCount(int val = 1){
        _count += val;
        CountText.text = _count.ToString();
    }
}