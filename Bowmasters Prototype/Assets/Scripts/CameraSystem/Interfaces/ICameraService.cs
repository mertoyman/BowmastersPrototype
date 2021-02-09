namespace CameraSystem.Interfaces
{
    public interface ICameraService
    {
        void ResetCameraOrthoSize();
        void OnGameStart();
        void SwitchCamera();      
        void FollowProjectile();
    }
}