using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.WebCam;

namespace FigureSkatingDigitalRulebook
{
    public class LoadingProcess : MonoBehaviour
    {
        [SerializeField]
        private RectTransform loadingImage;
        [SerializeField]
        private float rotateSpeed = 350f;
        [SerializeField]
        private GameObject videoCapture;
        [SerializeField]
        private GameObject nextScreen;

        private float timer = 0f;
        private float stopTimer = 3f;

        private void OnDisable()
        {
            timer = 0f;
        }

        void Update()
        {
            float currentSpeed = rotateSpeed * Time.deltaTime;
            loadingImage.Rotate(0f, 0f, currentSpeed);

            timer += Time.deltaTime;
            if (timer > stopTimer)
            {
                videoCapture.SetActive(false);
                nextScreen.SetActive(true);
                this.gameObject.SetActive(false);
            }
        }
    }
}
