using UI;
using UnityEngine;

namespace Finish
{
    public class FinishController : MonoBehaviour
    {
        private void OnEnable()
        {
            UIManager.OnGetFinishPosition += OnGetFinishPositionHandler;
        }

        private void OnDisable()
        {
            UIManager.OnGetFinishPosition -= OnGetFinishPositionHandler;
        }

        private float OnGetFinishPositionHandler() => transform.position.z;
    }
}
