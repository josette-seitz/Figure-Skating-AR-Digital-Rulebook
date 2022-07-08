using FigureSkatingDigitalRulebook;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

namespace UnityEngine.Windows.WebCam
{
    public class RecordSkater : MonoBehaviour
    {
        VideoCapture m_VideoCapture = null;

        private void OnEnable()
        {
            VideoCapture.CreateAsync(false, OnVideoCaptureCreated);
        }

        void OnVideoCaptureCreated(VideoCapture videoCapture)
        {
            if (videoCapture != null)
            {
                m_VideoCapture = videoCapture;

                Resolution cameraResolution = VideoCapture.SupportedResolutions.OrderByDescending((res) => res.width * res.height).First();
                float cameraFramerate = VideoCapture.GetSupportedFrameRatesForResolution(cameraResolution).OrderByDescending((fps) => fps).First();

                CameraParameters cameraParameters = new CameraParameters();
                // Do not show holograms, focus on the skater's spin to define level
                cameraParameters.hologramOpacity = 0.0f;
                cameraParameters.frameRate = cameraFramerate;
                cameraParameters.cameraResolutionWidth = cameraResolution.width;
                cameraParameters.cameraResolutionHeight = cameraResolution.height;
                cameraParameters.pixelFormat = CapturePixelFormat.BGRA32;

                // Audio does not matter, need to focus on skater's position of the spin
                m_VideoCapture.StartVideoModeAsync(cameraParameters,
                                                    VideoCapture.AudioState.None,
                                                    OnStartedVideoCaptureMode);
            }
            else
            {
                Debug.LogError("Failed to create VideoCapture Instance!");
            }
        }

        void OnStartedVideoCaptureMode(VideoCapture.VideoCaptureResult result)
        {
            if (result.success)
            {
                var spinType = SelectedSpin.spin;
                string timeStamp = Time.time.ToString().Replace(".", "").Replace(":", "");
                string filename = string.Format("{0}_{1}.mp4", spinType, timeStamp);
                string filepath = System.IO.Path.Combine(Application.persistentDataPath, filename);
                filepath = filepath.Replace("/", @"\");

                m_VideoCapture.StartRecordingAsync(filepath, OnStartedRecordingVideo);
            }
        }

        void OnStartedRecordingVideo(VideoCapture.VideoCaptureResult result)
        {
            Debug.Log("Started Recording Skater!");
        }

        // The coach has indicated to stop recording
        public void StopRecordingSkater()
        {
            m_VideoCapture.StopRecordingAsync(OnStoppedRecordingVideo);
        }

        void OnStoppedRecordingVideo(VideoCapture.VideoCaptureResult result)
        {
            Debug.Log("Stopped Recording Skater!");
            m_VideoCapture.StopVideoModeAsync(OnStoppedVideoCaptureMode);
        }

        void OnStoppedVideoCaptureMode(VideoCapture.VideoCaptureResult result)
        {
            m_VideoCapture.Dispose();
            m_VideoCapture = null;
        }
    }
}
