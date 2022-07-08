using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace FigureSkatingDigitalRulebook
{
    public class DebugPanel : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI logText;
        private string videoFilePath = "There are no Video Capture files.";

        public void ShowLogs()
        {
            logText.text = $"<b>Find Video Captures Here:</b> {videoFilePath}";
        }

        public void GetVideoPath()
        {
            // Video Capture will be taken over when filming demo for Hackathon, keep track of device path though
            videoFilePath = System.IO.Path.Combine(Application.persistentDataPath);
            videoFilePath = videoFilePath.Replace("/", @"\");

            Debug.Log($"Video File Path: {videoFilePath}");
        }
    }
}
