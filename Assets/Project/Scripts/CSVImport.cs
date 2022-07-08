using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace FigureSkatingDigitalRulebook
{
    public class CSVImport : MonoBehaviour
    {
        [SerializeField]
        private string rulebookDataType;
        private int id = 1;
        public static List<SpinData> spinDataInfo = new List<SpinData>();
        private const string spinFile = "Spins";
        // Add more in the future like jumpFile

        [System.Serializable]
        public class SpinData
        {
            public int skateId;
            public string spinType;
            public string spin;
            public string level;
            public string features;
            public string baseValue;
        }
        // Add more Seriabliable objects like Jumps in the future

        void Start()
        {
            TextAsset loadData = Resources.Load(spinFile) as TextAsset;
            string[] spiltData = loadData.text.Split('\n');
            // Remove empty last row
            spiltData = spiltData.Take(spiltData.Length - 1).ToArray();
            // Remove Header
            spiltData = spiltData.Where((source, index) => index != 0).ToArray();

            for (int i = 0; i < spiltData.Length; i++)
            {
                var data = spiltData[i].Split(',');

                // Parse data if choosen data to load is Spins
                if (rulebookDataType.Equals(spinFile))
                {
                    SpinData sd = new SpinData();
                    sd.skateId = id;
                    sd.spinType = data[0];
                    sd.spin = data[1].Replace('&', ',');
                    sd.level = data[2];
                    sd.features = data[3].Replace('&', ','); ;
                    sd.baseValue = data[4];

                    // Add data to application list
                    spinDataInfo.Add(sd);
                    id++;
                }
            }
        }
    }
}
