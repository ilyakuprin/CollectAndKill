using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CollectAndKill
{
    public abstract class JoystickHandler : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private Image _joystickArea;
        [SerializeField] private Image _joystickBackground;
        [SerializeField] private Image _joystick;

        [SerializeField] private Color _inactiveJoystickColor;
        [SerializeField] private Color _activeJoystickColor;

        private Vector2 _joystickCreationStartPosition;
        private Vector2 _inputVector;

        protected Vector2 GetInputVector { get => _inputVector; }

        private void Start()
        {
            _joystick.color = _inactiveJoystickColor;

            _joystickCreationStartPosition = _joystickBackground.rectTransform.anchoredPosition;
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(_joystickBackground.rectTransform, eventData.position, null, out Vector2 joystickPosition))
            {
                joystickPosition.x = joystickPosition.x * 2 / _joystickBackground.rectTransform.sizeDelta.x;
                joystickPosition.y = joystickPosition.y * 2 / _joystickBackground.rectTransform.sizeDelta.y;

                _inputVector = new Vector2(joystickPosition.x, joystickPosition.y);

                if (_inputVector.magnitude > 1f)
                {
                    _inputVector = _inputVector.normalized;
                }

                _joystick.rectTransform.anchoredPosition = new Vector2(_inputVector.x * (_joystickBackground.rectTransform.sizeDelta.x / 2),
                                                                       _inputVector.y * (_joystickBackground.rectTransform.sizeDelta.y / 2));
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _joystick.color = _activeJoystickColor;

            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(_joystickArea.rectTransform, eventData.position, null, out Vector2 joysicBackgroundPosition))
            {
                _joystickBackground.rectTransform.anchoredPosition = new Vector2(joysicBackgroundPosition.x, joysicBackgroundPosition.y);
            }
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _joystick.color = _inactiveJoystickColor;

            _joystickBackground.rectTransform.anchoredPosition = _joystickCreationStartPosition;

            _inputVector = Vector2.zero;
            _joystick.rectTransform.anchoredPosition = Vector2.zero;
        }
    }
}
