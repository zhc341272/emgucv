//----------------------------------------------------------------------------
//  Copyright (C) 2004-2020 by EMGU Corporation. All rights reserved.       
//----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Emgu.Util;
using System.Diagnostics;

namespace Emgu.CV.IntensityTransform
{
    internal static partial class IntensityTransformInvoke
    {
        static IntensityTransformInvoke()
        {
            CvInvoke.CheckLibraryLoaded();
        }

        
        public static void LogTransform(Mat input, Mat output)
        {
            cveLogTransform(input, output);
        }
        [DllImport(CvInvoke.ExternLibrary, CallingConvention = CvInvoke.CvCallingConvention)]
        internal static extern void cveLogTransform(IntPtr input, IntPtr output);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="output"></param>
        /// <param name="gamma"></param>
        public static void GammaCorrection(Mat input, Mat output, float gamma)
        {
            cveGammaCorrection(input, output, gamma);
        }
        [DllImport(CvInvoke.ExternLibrary, CallingConvention = CvInvoke.CvCallingConvention)]
        internal static extern void cveGammaCorrection(IntPtr input, IntPtr output, float gamma);

        /// <summary>
        /// Given an input bgr or grayscale image, apply autoscaling on domain [0, 255] to increase the contrast of the input image and return the resulting image.
        /// </summary>
        /// <param name="input">Input bgr or grayscale image.</param>
        /// <param name="output">Resulting image of autoscaling.</param>
        public static void Autoscaling(Mat input, Mat output)
        {
            cveAutoscaling(input, output);
        }
        [DllImport(CvInvoke.ExternLibrary, CallingConvention = CvInvoke.CvCallingConvention)]
        internal static extern void cveAutoscaling(IntPtr input, IntPtr output);

        /// <summary>
        /// Given an input bgr or grayscale image, apply linear contrast stretching on domain [0, 255] and return the resulting image.
        /// </summary>
        /// <param name="input">Input bgr or grayscale image.</param>
        /// <param name="output">Resulting image of contrast stretching.</param>
        /// <param name="r1">x coordinate of first point (r1, s1) in the transformation function.</param>
        /// <param name="s1">y coordinate of first point (r1, s1) in the transformation function.</param>
        /// <param name="r2">x coordinate of second point (r2, s2) in the transformation function.</param>
        /// <param name="s2">y coordinate of second point (r2, s2) in the transformation function.</param>
        public static void ContrastStretching(Mat input, Mat output, int r1, int s1, int r2, int s2)
        {
            cveContrastStretching(input, output, r1, s1, r2, s2);
        }
        [DllImport(CvInvoke.ExternLibrary, CallingConvention = CvInvoke.CvCallingConvention)]
        internal static extern void cveContrastStretching(IntPtr input, IntPtr output, int r1, int s1, int r2, int s2);

        /// <summary>
        /// Given an input color image, enhance low-light images using the BIMEF method
        /// </summary>
        /// <param name="input">Input color image.</param>
        /// <param name="output">Resulting image.</param>
        /// <param name="mu">Enhancement ratio.</param>
        /// <param name="a">a-parameter in the Camera Response Function (CRF).</param>
        /// <param name="b">b-parameter in the Camera Response Function (CRF).</param>
        public static void BIMEF(IInputArray input, IOutputArray output, float mu = 0.5f, float a = -0.3293f, float b = 1.1258f)
        {
            using (InputArray iaInput = input.GetInputArray())
            using (OutputArray oaOutput = output.GetOutputArray())
                cveBIMEF(iaInput, oaOutput, mu, a, b);
        }
        [DllImport(CvInvoke.ExternLibrary, CallingConvention = CvInvoke.CvCallingConvention)]
        internal static extern void cveBIMEF(IntPtr input, IntPtr output, float mu, float a, float b);

        /// <summary>
        /// Given an input color image, enhance low-light images using the BIMEF method
        /// </summary>
        /// <param name="input">Input color image.</param>
        /// <param name="output">Resulting image.</param>
        /// <param name="k">Exposure ratio.</param>
        /// <param name="mu">Enhancement ratio.</param>
        /// <param name="a">a-parameter in the Camera Response Function (CRF).</param>
        /// <param name="b">b-parameter in the Camera Response Function (CRF).</param>
        public static void BIMEF(IInputArray input, IOutputArray output, float k, float mu, float a, float b)
        {
            using (InputArray iaInput = input.GetInputArray())
            using (OutputArray oaOutput = output.GetOutputArray())
                cveBIMEF2(iaInput, oaOutput, k, mu, a, b);
        }
        [DllImport(CvInvoke.ExternLibrary, CallingConvention = CvInvoke.CvCallingConvention)]
        internal static extern void cveBIMEF2(IntPtr input, IntPtr output, float k, float mu, float a, float b);

    }
}
