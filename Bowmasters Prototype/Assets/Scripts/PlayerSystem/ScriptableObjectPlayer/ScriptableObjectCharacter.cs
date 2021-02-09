using UnityEngine;

namespace PlayerSystem
{
    [CreateAssetMenu(fileName = "Character", menuName = "Bowmasters/CreatePlayer", order = 0)]
    public class ScriptableObjectCharacter : ScriptableObject
    {
        public PlayerView playerView;
        public NPCView npcView;
        public Vector2 playerSpawnPosition;
        public Vector2 npcSpawnPosition;
        public float health;
    }
}