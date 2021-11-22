using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class UI : MonoBehaviour
{
    [SerializeField] private GameObject StartMenu;
    [SerializeField] private GameObject RestartMenu;

    private int GettedCubesCount;

    public static UI Instance {get; private set; }
    public event Action GameStartedEvent;

    private void Awake(){
        Instance = this;
    }
    private void Start(){
        RestartMenu.SetActive(false);
    }
    private void OnDestroy(){

    }
    
    public void StartButtonClick(){
        StartMenu.SetActive(false);
        GameStartedEvent?.Invoke();
    }
    public void RestartButtonClick(){
        SceneManager.LoadScene("SampleScene");
    }
}