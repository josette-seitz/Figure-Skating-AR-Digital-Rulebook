using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

namespace FigureSkatingDigitalRulebook
{
    public class SkaterResults : MonoBehaviour
    {
        [SerializeField]
        private TextMeshPro skatetype;
        [SerializeField]
        private TextMeshPro spin;
        [SerializeField]
        private TextMeshPro level;
        [SerializeField]
        private TextMeshPro features;
        [SerializeField]
        private TextMeshPro baseValue;
        [SerializeField]
        private GameObject combinationExtra;

        private void OnEnable()
        {
            var spinResult = CSVImport.spinDataInfo.Where(s => s.skateId == (int)SelectedSpin.spin).FirstOrDefault();

            skatetype.text = spinResult.spinType;
            spin.text = spinResult.spin;
            level.text = spinResult.level;
            features.text = spinResult.features;
            baseValue.text = spinResult.baseValue;

            if (spinResult.spinType.ToUpper() == "COMBINATION")
            {
                combinationExtra.SetActive(true);
            }
            else
            {
                combinationExtra.SetActive(false);
            }
        }
    }
}
