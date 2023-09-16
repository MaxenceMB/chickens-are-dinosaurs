using UnityEngine;

public class PauseMenuScript : MonoBehaviour {

    [SerializeField] private GameObject menu;
    private bool paused = false;

    private void Start() {
        menu.SetActive(false);
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            this.paused = !this.paused;
        }
        
        if(paused) {
            this.PauseGame();
        } else {
            this.ResumeGame();
        }
    }

    public void PauseGame() {
        Time.timeScale = 0;
        menu.SetActive(true);
    }

    public void ResumeGame() {
        menu.SetActive(false);
        Time.timeScale = 1;
    }
}
