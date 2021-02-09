using UnityEngine;
using Zenject;

namespace InputSystem
{
    public class MouseInput : IInputComponent
    {
        private IInputService _inputService;
        
        private Vector2 startPosition, endPosition;
        private Vector2 forwardPosition;
        private float currentForce;
        private float angle;

        private InputStatus inputStatus=InputStatus.INVALID;
        
        public MouseInput(IInputService inputService)
        {
            _inputService = inputService;
        }
        
        public void OnTick()
        {
            if (Input.GetMouseButtonDown(0) && _inputService.CheckForCharacterPresence(Input.mousePosition))
            {
                inputStatus =InputStatus.VALID;
                startPosition = Input.mousePosition;
                endPosition = Input.mousePosition;
                forwardPosition = _inputService.GetPlayerForwardDirection();
                InputData inputData = CreateInputData(startPosition, endPosition);
                _inputService.SendPlayerData(inputData, true);
               
            }

            if (Input.GetMouseButton(0) && inputStatus ==InputStatus.VALID)
            {
                endPosition = Input.mousePosition;
                InputData inputData = CreateInputData(startPosition, endPosition);
                _inputService.SendPlayerData(inputData, true);
            }

            if (Input.GetMouseButtonUp(0) && inputStatus ==InputStatus.VALID)
            {
                endPosition = Input.mousePosition;
                InputData inputData = CreateInputData(startPosition, endPosition);
                _inputService.SendPlayerData(inputData, false);
                inputStatus = InputStatus.INVALID;
            }
        }

        InputData CreateInputData(Vector2 startPos, Vector2 endPos)
        {
            CalculateAngleAndForce(startPos, endPos);
            InputData inputData = new InputData();
            inputData.angleValue = angle;
            inputData.forceValue = currentForce;
            return inputData;
        }
        
        

        void CalculateAngleAndForce(Vector2 startPos, Vector2 endPos)
        {
            Vector2 vectorA = new Vector2(endPos.x - startPos.x, endPos.y - startPos.y);
            float currentDistance = Vector2.SqrMagnitude(vectorA);
            currentDistance = Mathf.Sqrt(currentDistance);
            currentForce = currentDistance;

            if (currentForce > 30)
            {
                currentForce = 30f;
            }
            angle = Vector2.SignedAngle(vectorA, forwardPosition);
            angle = angle >= 0 ? 180 - angle : -(180 + angle);
        }
    }
}