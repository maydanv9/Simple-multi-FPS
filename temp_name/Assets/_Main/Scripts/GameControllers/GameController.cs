using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("MAIN CONTROLLER")]
    [SerializeField] private UIController uiController;
    public UIController UIController => uiController;

    [SerializeField] private InputController inputController;
    public InputController InputController => inputController;

    [SerializeField] private MovementController movementController;
    public MovementController MovementController => movementController;

    [SerializeField] private SceneReferences sceneReferences;
    public SceneReferences SceneReferences => sceneReferences;


    private void Awake()
    {
        Initialization();
        AssignAnalytics();
    }

    void Initialization()
    {
        ChangeState(new MenuState());
    }

    void AssignAnalytics()
    {

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
