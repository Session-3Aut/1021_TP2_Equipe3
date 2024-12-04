using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangementScene : MonoBehaviour

{

// [SerializeField] AudioSource audioSource;   
  // Changement de la scène actuelle vers une scène spécifique par son nom.
  public void ChangeScene(string _nomScene)
    { 
     SceneManager.LoadScene(_nomScene);
    //  audioSource.Play();
    }
}
