using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class TransitionScript : MonoBehaviour
{
    private Animator _anim;

    public static string transitioning = "";

    private static TransitionScript _singleton;
    public static TransitionScript Singleton
    {
        get
        {
            if (_singleton == null)
            {
                _singleton = Instantiate(Resources.Load<GameObject>("Prefabs/Transition")).GetComponent<TransitionScript>();
            }
            return _singleton;
        }
        private set
        {
            _singleton = value;
        }
    }

    private void Awake()
    {
        if (_singleton) // Destroy yourself if you already exist
        {
            Destroy(gameObject);
            return;
        }
        // Lorsque l'instance se démarre, on tente de l'assigner au Singleton. Si elle existe déjà, cette instance sera détruite.
        Singleton = this;
        transform.SetParent(null, false); // Met le transform au plus haut de la hiérarchie pour permettre le DontDestroyOnLoad
        DontDestroyOnLoad(this); // Permet de garder le même Singleton entre les chargements de scène.

        _anim = gameObject.GetComponent<Animator>();
        transitioning = "";
        SceneManager.sceneLoaded += OnSceneLoaded; // On abonne la fontion OnSceneLoaded à l'événement de chargement de scène du SceneManager.
    }

    public static void TransitionTo(string SceneName = "MainMenu")
    {
        Singleton.BeginTransition(SceneName);
    }

    private void BeginTransition(string SceneName)
    {
        if (transitioning == "") // There is not a transition already playing
        {
            Debug.Log("Called!!");
            transitioning = SceneName;
            _anim.Play("CloseTransition"); // Plays the transition anim
        }
    }

    public void TransitionFinished() // When the transition anim is done playing
    {
        if (transitioning != "")
        {
            SceneManager.LoadScene(transitioning); // Load the scene
            transitioning = "";
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode) // When the scene is done loading
    {
        _anim.Play("OpenTransition"); // Play the transition open anim
        transitioning = "";
    }
}
