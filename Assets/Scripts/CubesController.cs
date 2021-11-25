using UnityEngine;

public class CubesController : MonoBehaviour
{
    [SerializeField] private GameObject RestartMenu;
    private int _gettedCubes = 0;

    public void AddGettedCube(){
        _gettedCubes ++;
        if (_gettedCubes == GameController._cubesCount){
            RestartMenu.SetActive(true);
        }
    }
}
