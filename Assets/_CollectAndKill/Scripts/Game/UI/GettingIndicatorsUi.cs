using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CollectAndKill
{
    public class GettingIndicatorsUi : MonoBehaviour
    {
        private readonly StringTags _stringTags = new();
        private Transform _indicators;

        private Sprite _icon;
        public Sprite Icon { set => _icon = value; }

        private void Awake()
        {
            _indicators = GameObject.FindGameObjectWithTag(_stringTags.TagListOfPlayer).transform;
        }

        private void Start()
        {
            BindIndicators();
            PurposeIndicators();
        }

        private void BindIndicators()
        {
            for (int i = 0; i < _indicators.childCount; i++)
            {
                GameObject obj = _indicators.GetChild(i).gameObject;

                if (!obj.activeInHierarchy)
                {
                    obj.SetActive(true);
                    _indicators = obj.transform;
                    break;
                }
            }
        }

        private void PurposeIndicators()
        {
            for (int i = 0; i < _indicators.childCount; i++)
            {
                if (_indicators.GetChild(i).CompareTag(_stringTags.TagCoinCounter)) //привязываю монетки
                {
                    IndicatorVisualization indicatorVisualization = _indicators.GetChild(i).GetComponent<IndicatorVisualization>();
                    CoinPicker coinPicker = GetComponent<CoinPicker>();

                    indicatorVisualization.MaxValue = coinPicker.MaxCoin;
                    coinPicker.CoinTaken += indicatorVisualization.ChangeIndicator;
                }
                else if (_indicators.GetChild(i).CompareTag(_stringTags.TagHealthBar)) //привязываю здоровье
                {
                    IndicatorVisualization indicatorVisualization = _indicators.GetChild(i).GetComponent<IndicatorVisualization>();
                    HealthHandler healthHandler = GetComponent<HealthHandler>();

                    indicatorVisualization.MaxValue = healthHandler.GetMaxHealth;
                    healthHandler.DamageTaken += indicatorVisualization.ChangeIndicator;
                }
                else if (_indicators.GetChild(i).CompareTag(_stringTags.TagIcon)) //привязываю иконку
                {
                    _indicators.GetChild(i).GetComponent<Image>().sprite = _icon;
                }
                else if (_indicators.GetChild(i).TryGetComponent(out TMP_Text name)) //привязываю имя
                {
                    name.text = GetComponent<PhotonView>().Owner.NickName;
                }
            }
        }
    }
}
