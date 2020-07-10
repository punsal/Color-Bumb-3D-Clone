using UnityEngine;

namespace Level
{
    public class LevelManager : MonoBehaviour
    {
        #pragma warning disable 649
        [SerializeField] private Transform endPointTransform;
        #pragma warning restore 649

        public Vector3 EndPosition => endPointTransform.position;
    }
}