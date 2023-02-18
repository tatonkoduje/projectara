using Unity.VisualScripting;
using UnityEngine;

namespace Game
{
    public class RoomView : MonoBehaviour
    {
        public SpriteRenderer dangerNumberSpriteRenderer;

        [SerializeField]
        private Sprite[] dangerNumberSprites;

        public void ChangeDangerNumber(int value)
        {
            dangerNumberSpriteRenderer.sprite = value != -1 ? dangerNumberSprites[value] : null;
        }
    }
}