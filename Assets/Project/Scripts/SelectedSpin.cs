using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FigureSkatingDigitalRulebook
{
    public class SelectedSpin : MonoBehaviour
    {
        public static Enums.Spin spin;

        public void UserSelectSpin(int s)
        {
            spin = (Enums.Spin)s;
        }
    }
}
