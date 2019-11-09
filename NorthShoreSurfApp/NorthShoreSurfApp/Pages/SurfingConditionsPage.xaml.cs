using LibVLCSharp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NorthShoreSurfApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SurfingConditionsPage : ContentPage
    {
        const string VIDEO_URL = "rtsp://184.72.239.149/vod/mp4:BigBuckBunny_175k.mov";
        readonly LibVLC _libvlc;
        private const string CamOnLiveVideoUrl = "rtsp://127.0.0.1:8080/video/h264";
        private const string IpWebcamVideoUrl = "rtsp://192.168.10.112:8080/h264_pcm.sdp";

        public SurfingConditionsPage()
        {
            InitializeComponent();

            Core.Initialize();
            // instantiate the main libvlc object
            _libvlc = new LibVLC();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            vvWebcam.MediaPlayer = new MediaPlayer(_libvlc);
            vvWebcam.MediaPlayer.Play(new Media(_libvlc, CamOnLiveVideoUrl, FromType.FromLocation));
        }
    }
}