using com.maapiid.projectara.Core;


namespace GameData
{
    [System.Serializable]
    public class PlayerData
    {
        public float Speed;
        public float[] Position;

        public PlayerData(Player player)
        {
            Speed = player.speed;
            Position = new float[3];
            
            var position = player.transform.position;
            Position[0] = position.x;
            Position[1] = position.y;
            Position[2] = position.z;
        }
    }
}