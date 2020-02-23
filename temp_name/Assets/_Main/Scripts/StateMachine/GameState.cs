using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        //SceneManager.LoadSceneAsync(Keys.Scenes.TERRAIN_SCENE);
        gameController.WebController.Client.Init(gameController);
        gameController.WebController.Client.ConnectToServer();
        gameController.MovementController.Init(gameController);
        gameController.PlayersController.Init(gameController);
    }

    public override void UpdateState(GameController gameController)
    {
        gameController.InputController.InputUpdate();
        gameController.PlayersController.LocalPlayer.MyUpdate(inputs);
        //gameController.MovementController.UpdateInputs(inputs);
        //gameController.MovementController.MovementUpdate();
        //gameController.MovementController.LookUpdate();
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
