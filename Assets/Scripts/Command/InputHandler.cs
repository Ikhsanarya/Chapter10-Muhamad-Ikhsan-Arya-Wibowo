using System;
using System.Collections.Generic;
using UnityEngine;

namespace Command
{
    public enum InputType
    {
        Keyboard
    }
    
    public class InputHandler: MonoBehaviour
    {
        public CircleController circleController;
        public InputType inputType;
        
        private Queue<Command> commands = new Queue<Command>();

        private void FixedUpdate()
        {
            if (inputType == InputType.Keyboard)
            {
                Command moveCommand = HandleKeyboardInput();
                if (moveCommand != null)
                {
                    commands.Enqueue(moveCommand);
                    moveCommand.Execute();
                }
            }
        }

        private Command HandleKeyboardInput()
        {
            float inputX = Input.GetAxis("Horizontal");
            float inputY = Input.GetAxis("Vertical");
            
            return new KeyboardMove(circleController, inputX, inputY);
        }
            
    }
}
