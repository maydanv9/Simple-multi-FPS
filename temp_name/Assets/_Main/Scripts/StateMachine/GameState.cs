using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : BaseState, IGameView, IMovement
{

    private InputController.InputValues inputs;

    public override void InitState(GameController gameController)
    {
        base.InitState(gameController);
        #region LISTENERS
        gameController.UIController.GameView.listener = this;
        gameController.InputController.movementlistener = this;
        #endregion 
        gameController.UIController.GameView.ShowView();
        gameController.WebController.Client.ConnectToServer();
        gameController.SceneReferences.GameTerrain.SetActive(true);
        gameController.MovementController.Init(gameController);
    }

    public override void UpdateState(GameController gameController)
    {
        gameController.InputController.InputUpdate();
        gameController.MovementController.UpdateInputs(inputs);
        foreach(PlayerController player in gameController.PlayersController.playerControllerList)
        {
            player.MyUpdate();
        }
        gameController.MovementController.MovementUpdate();
        gameController.MovementController.LookUpdate();
    }

    public override void DeinitState(GameController gameController)
    {
        base.DeinitState(gameController);
        #region LISTENERS
        gameController.UIController.GameView.listener = this;
        gameController.InputController.movementlistener = this;
        #endregion 
        gameController.UIController.GameView.HideView();
    }

    public void SetMenuState()
    {
        gameController.ChangeState(new MenuState());

    }

    #region INTERFACES
    public void UpdateAxis(InputController.InputValues inputValues)
    {
        inputs = inputValues;
    }
    #endregion
}
