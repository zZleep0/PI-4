using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoviment : MonoBehaviour
{
    [SerializeField] float speed = 10;
    private Vector2 inputDirection;

    private bool movingByMouse = false;
    private Vector3 origin;
    private Vector3 diference;
    private Camera cameraMain;

    void Start()
    {
        cameraMain = Camera.main;
    }

    void LateUpdate()
    {
        //Se nao estiver no estado de explorar, nao e possivel se mover
        if (GameStates.Instance.GetState() != GameStates.GameState.Exploring)
        {
            return;
        }

        MoveByMouseDrag();

        if(!movingByMouse)
        {
            MoveByButtonsKeys();
        }

    }

    private void MoveByMouseDrag()
    {
        if(InputManager.Instance.GetLeftClickPressed())
        {
            diference = (cameraMain.ScreenToWorldPoint(Input.mousePosition)) - cameraMain.transform.position;
            if(!movingByMouse)
            {
                movingByMouse = true;
                origin = cameraMain.ScreenToWorldPoint(Input.mousePosition);
            }
            cameraMain.transform.position = origin - diference;
        }
        else
        {
            movingByMouse = false;
        } 
    }

    private void MoveByButtonsKeys()
    {
        inputDirection = InputManager.Instance.GetMoveDirection();
        transform.Translate(inputDirection * speed * Time.deltaTime);
    }
}
