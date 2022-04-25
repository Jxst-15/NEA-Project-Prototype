using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // If space pressed
        {
            resetScene();
        }
    }

    private void resetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reloads scene
    }
}
