﻿using System;
using OpenTK;
using OpenTK.Input;

namespace LudumGL.Debugging
{
    /// <summary>
    /// A debugging tool that will provide you with a controllable
    /// flying camera.
    /// </summary>
    public class FlyingCamera : IDebugObject
    {
        public Camera Camera { get; } = new Camera() { FarClip=1000f};
        public float Speed { get; set; } = 0.5f;
        public bool NeedsMouseInput { get; set; }

        public float RotationSpeed { get; set; } = 2f;

        public FlyingCamera()
        {

        }

        public FlyingCamera(Vector3 position)
        {
            Camera.Transform.localPosition = position;
        }

        public FlyingCamera(float x, float y, float z)
        {
            Camera.Transform.localPosition = new Vector3(x, y, z);
        }

        public void Update()
        {
            if(!NeedsMouseInput || Input.GetButtonDown(MouseButton.Right))
            {
                if (Input.GetKey(Key.W))
                {
                    Camera.Transform.localPosition += Camera.Transform.Forward * Speed;
                }
                if (Input.GetKey(Key.S))
                {
                    Camera.Transform.localPosition -= Camera.Transform.Forward * Speed;
                }
                if (Input.GetKey(Key.A))
                {
                    Camera.Transform.localPosition -= Camera.Transform.Right * Speed;
                }
                if (Input.GetKey(Key.D))
                {
                    Camera.Transform.localPosition += Camera.Transform.Right * Speed;
                }
                if (Input.GetKey(Key.Q))
                {
                    Camera.Transform.Rotate(0, 0, -RotationSpeed);
                }
                if (Input.GetKey(Key.E))
                {
                    Camera.Transform.Rotate(0, 0, RotationSpeed);
                }
                if (Game.window.Focused)
                    Camera.Transform.Rotate(-Input.MouseDelta.Y, -Input.MouseDelta.X, 0);
            }
        }

        public void Render()
        {

        }
    }
}
