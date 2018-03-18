using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour {
    public float moveCameraHorizontal = 0f;
    public float moveCameraVertical = 0f;
    public float zoomLevel = 1f;
    public UnitController unitController;

    private float borderTreshold = 0.1f;
    private bool leftPressed = false;
    private bool rightPressed = false;
    void Update() {
        //Debug.Log("Debug: " + "Hello world");
        UpdateHorizontal();
        UpdateVertical();
        UpdateZoom();
        UpdateLeftClick();
        UpdateRightClick();
    }

    void UpdateLeftClick()
    {
        if (Input.GetAxisRaw("LeftPress") == 0 && leftPressed == true)
        {
            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            bool additative = (Input.GetKey(KeyCode.LeftShift)); // Fix to allow to remake hotkeys?
            unitController.Select(mouseRay, additative);
        }
        if (Input.GetAxisRaw("LeftPress") == 1)
        {
            leftPressed = true;
        } else
        {
            leftPressed = false;
        }
    }

    void UpdateRightClick()
    {
        if (Input.GetAxisRaw("RightPress") == 0 && rightPressed == true)
        {
            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            unitController.RightClick(mouseRay);
        }
        if (Input.GetAxisRaw("RightPress") == 1)
        {
            rightPressed = true;
        }
        else
        {
            rightPressed = false;
        }
    }

    private void UpdateZoom()
    {
        zoomLevel -= Input.GetAxisRaw("Mouse ScrollWheel");
        if (zoomLevel < 0.1f) zoomLevel = 0.1f;
        if (zoomLevel > 4f) zoomLevel = 4f;
    }

    private void UpdateHorizontal()
    {
        float mouseX = Input.mousePosition.x;
        float borderLeft = (float)Screen.width * borderTreshold;
        float borderRight = (float)Screen.width - (Screen.width * borderTreshold);
        if (Input.GetAxisRaw("Horizontal") > 0f)
        {
            moveCameraHorizontal = Input.GetAxisRaw("Horizontal");
        }
        else if (Input.GetAxisRaw("Horizontal") < 0f)
        {
            moveCameraHorizontal = Input.GetAxisRaw("Horizontal");
        }
        else if (mouseX < borderLeft && mouseX >= 0)
        {
            moveCameraHorizontal = (1 - mouseX / borderLeft) * -1;
        }
        else if (mouseX > borderRight && mouseX <= Screen.width)
        {
            moveCameraHorizontal = (mouseX - borderRight) / (Screen.width * borderTreshold) * 1;
        }
        else
        {
            moveCameraHorizontal = 0f;
        }
    }

    private void UpdateVertical()
    {
        float mouseY = Input.mousePosition.y;
        float borderBottom = (float)Screen.height * borderTreshold;
        float borderTop = (float)Screen.height - (Screen.height * borderTreshold);
        if (Input.GetAxisRaw("Vertical") > 0f)
        {
            moveCameraVertical = Input.GetAxisRaw("Vertical");
        }
        else if (Input.GetAxisRaw("Vertical") < 0f)
        {
            moveCameraVertical = Input.GetAxisRaw("Vertical");
        }
        else if (mouseY < borderBottom && mouseY >= 0)
        {
            moveCameraVertical = (1 - mouseY / borderBottom) * -1;
        }
        else if (mouseY > borderTop && mouseY <= Screen.height)
        {
            moveCameraVertical = (mouseY - borderTop) / (Screen.height * borderTreshold) * 1;
        }
        else
        {
            moveCameraVertical = 0f;
        }
    }
}
