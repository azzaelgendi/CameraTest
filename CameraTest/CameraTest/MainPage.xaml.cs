using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using Android.Media;

namespace CameraTest
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            CameraButton.Clicked += CameraButton_Clicked;//there is abutton to be clicked to open the camera
        }

        private async void CameraButton_Clicked(object sender, EventArgs e)//the event handler will be your menu
        {
            
            var photo = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions() { });
            var path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);//having problem to store in a path
            if (photo != null)
                PhotoImage.Source = ImageSource.FromStream(() => { return photo.GetStream(); });
            ExifInterface newExif = new ExifInterface(path);
            newExif.SetAttribute(ExifInterface.TagGpsLatitude, "teste lat");
            newExif.SetAttribute(ExifInterface.TagGpsLatitudeRef, "teste lat ref");
            newExif.SetAttribute(ExifInterface.TagGpsLongitude, "teste long");
            newExif.SetAttribute(ExifInterface.TagGpsLongitudeRef, "teste long ref");
            newExif.SetAttribute(ExifInterface.TagGpsDatestamp, "GPSDatestamp");
            newExif.SetAttribute(ExifInterface.TagDatetime, "Date Time");
            newExif.SaveAttributes();
        }
    }
}
