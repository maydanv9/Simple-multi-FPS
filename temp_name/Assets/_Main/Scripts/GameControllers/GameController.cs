using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController gameControllerInstance;

    [Header("MAIN CONTROLLER")]
    [SerializeField] private UIController uiController;
    public UIController UIController => uiController;

    [SerializeField] private InputController inputController;
    public InputController InputController => inputController;

    [SerializeField] private MovementController movementController;
    public MovementController MovementController => movementController;

    [SerializeField] private SceneReferences sceneReferences;
    public SceneReferences SceneReferences => sceneReferences;

    [SerializeField] private WebController webController;
    public WebController WebController => webController;

    [SerializeField] private PlayersController playersController;
    public PlayersController PlayersController => playersController;


    private void Awake()
    {
        Initialization();
        AssignAnalytics();
        GenerateGC();
    }

    void Initialization()
    {
        ChangeState(new MenuState());
    }

    void AssignAnalytics()
    {

    }

    void GenerateGC()
    {
        if (gameControllerInstance == null)
        {
            gameControllerInstance = this;
        }
        else if (gameControllerInstance != this)
        {
            Debug.Log("Instance already exists, destroying object!");
            Destroy(this);
        }
    }

    BaseState currrentState;

    public void ChangeState(BaseState newState)
    {
        if (currrentState != null)
        {
            currrentState.DeinitState(this);
        }

        currrentState = newState;

        if (currrentState != null)
        {
            currrentState.InitState(this);
        }
    }

    private void Update()
    {
        if (currrentState != null)
        {
            currrentState.UpdateState(this);
        }
    }


}
