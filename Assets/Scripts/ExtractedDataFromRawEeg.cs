using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class ExtractedDataFromRawEeg
    {
        public float[] FrequencyBandsData = new float[5]; // Delta, Theta, Alpha, Beta, Concentration ratio (Beta/Theta)


        private float delta;
        public float Delta
        {
            get { return delta; }
            set { delta = Math.Max(value, 0); }
        }

        private float theta;
        public float Theta
        {
            get { return theta; }
            set { theta = Math.Max(value, 0); }
        }

        private float alpha;
        public float Alpha
        {
            get { return alpha; }
            set { alpha = Math.Max(value, 0); }
        }

        private float beta;
        public float Beta
        {
            get { return beta; }
            set { beta = Math.Max(value, 0); }
        }

        private float concentrationRatio;
        public float ConcentrationRatio
        {
            get { return concentrationRatio; }
            set { concentrationRatio = Math.Max(value, 0); }
        }

    }
}