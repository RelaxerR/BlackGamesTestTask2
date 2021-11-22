using UnityEngine;

public class CubesController : MonoBehaviour
{
    [SerializeField] private GameObject RestartMenu;
    private int GettedCubes = 0;

    public void AddGettedCube(){
        GettedCubes ++;
        if (GettedCubes == GameController._CubesCount){
            RestartMenu.SetActive(true);
        }
    }
}
