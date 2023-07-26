using OpenCvSharp;
using OpenCvSharp.XFeatures2D;
using System;
using System.Windows.Forms;

namespace Feature_Matching
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            // InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // 비교 이미지 입력1
            var img1 = new Mat(@"1.bmp", ImreadModes.Grayscale);
            Cv2.WaitKey(1); // do events
            Mat Mat_dst = img1.SubMat(new Rect(700, 600, 900, 1000));// 전체이미지에서 비교할 부분이미지를 사각형으로 추출한다.


            // 비교 이미지 입력2
            var img2 = new Mat(@"2.bmp", ImreadModes.Grayscale);
            Cv2.WaitKey(1); // do events
            Mat Mat_dst2 = img2.SubMat(new Rect(700, 600, 900, 1000));// 전체이미지에서 비교할 부분이미지를 사각형으로 추출한다.

            // 키포인트 검출

            // FastFeatureDetector, StarDetector, SIFT, SURF, ORB, BRISK, MSER, GFTTDetector, DenseFeatureDetector, SimpleBlobDetector

            // SURF = Speeded Up Robust Features

            var Detector = SURF.Create(hessianThreshold: 400); //A good default value could be from 300 to 500, depending from the image contrast.
            var keypoints1 = Detector.Detect(Mat_dst);
            var keypoints2 = Detector.Detect(Mat_dst2);


            // descriptors 계산, BRIEF, FREAK

            // BRIEF = Binary Robust Independent Elementary Features

            var extractor = BriefDescriptorExtractor.Create();
            var Descriptors1 = new Mat();
            var Descriptors2 = new Mat();

            extractor.Compute(Mat_dst, ref keypoints1, Descriptors1);
            extractor.Compute(Mat_dst2, ref keypoints2, Descriptors2);

            // matching descriptors
            var matcher = new BFMatcher();
            var matches = matcher.Match(Descriptors1, Descriptors2);

            // drawing the results
            var imgMatches = new Mat();

            Cv2.DrawMatches(Mat_dst, keypoints1, Mat_dst2, keypoints2, matches, imgMatches);
            Cv2.ImShow("Matches", imgMatches);

            double number_keypoints = 0;
            double number_keypoints2 = 0;

            if (keypoints1.Length <= keypoints2.Length)
            {
                number_keypoints = keypoints1.Length;
                number_keypoints2 = keypoints2.Length;
            }

            else
            {
                number_keypoints = keypoints2.Length;
                number_keypoints2 = keypoints1.Length;
            }

            Console.WriteLine("Keypoints 1ST Image: " + keypoints1.Length);
            Console.WriteLine("Keypoints 2ND Image: " + keypoints2.Length);
            Console.WriteLine("Score: " + (double)number_keypoints / number_keypoints2);

            Cv2.WaitKey(1); // do events
            Cv2.WaitKey(0);
            Cv2.DestroyAllWindows();
            Mat_dst.Dispose();
            Mat_dst2.Dispose();

        }
    }
}