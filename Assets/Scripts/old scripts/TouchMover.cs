using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


namespace SnowManRun
{
    public class TouchMover : MonoBehaviour
    {
        private enum ControlMode { Keyboard, Touchscreen}
        [SerializeField] private ControlMode m_controlMode;

        //Touch Part
        private Vector3 position;
        private float width;
        private float height;

        [SerializeField] private float roadWidth;
        private float leftX;
        private float offsetX;

        //Keyboard part
        private float x_l;
        private float x_r;
        [SerializeField] private float speed = 1;
        private float curentX = 0;


        void Awake()
        {
            width = (float)Screen.width;

            // Position used for the cube.
            position = new Vector3(0.0f, 0.0f, 0.0f);
        }

        private void Start()
        {
            leftX = 0 - (roadWidth / 2);
            offsetX = (roadWidth) / 100;

            x_r = roadWidth / 2;
            x_l = 0 - x_r;

            if (Application.isMobilePlatform) m_controlMode = ControlMode.Touchscreen;
        }

/*        void OnGUI()
        {
            // Compute a fontSize based on the size of the screen width.
            GUI.skin.label.fontSize = (int)(Screen.width / 25.0f);

            GUI.Label(new Rect(20, 20, width, height * 0.25f),
                "x = " + position.x.ToString("f2") +
                ", y = " + position.y.ToString("f2"));
        }*/

        void FixedUpdate()
        {
            if(m_controlMode==ControlMode.Touchscreen)
            {
                TouchScreenControl();
            }
            else
            {
                KeyBoardControl();
            }    
        }

        private void TouchScreenControl()
        {
            // Handle screen touches.
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                // Move the cube if the screen has the finger moving.
                if (touch.phase == TouchPhase.Moved)
                {
                    Vector2 pos = touch.position;
                    float proc = pos.x / (width / 100);

                    Vector3 transP = transform.position;
                    float newX = leftX + (proc * offsetX);
                    position = new Vector3(newX, transP.y, transP.z);

                    // Position the cube.
                    transform.position = position;
                }
            }
        }

        private void KeyBoardControl()
        {
            //control by keyboard

            if(Input.GetKey(KeyCode.RightArrow))
            {
                if(curentX<x_r)
                {
                    curentX += (Time.fixedDeltaTime * speed);
                    if (curentX > x_r) curentX = x_r;
                }
            }

            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                if (curentX > x_l)
                {
                    curentX -= (Time.fixedDeltaTime * speed);
                    if (curentX < x_l) curentX = x_l;
                }
            }

            transform.position = new Vector3(curentX, transform.position.y, transform.position.z);
        }

    }    
}
