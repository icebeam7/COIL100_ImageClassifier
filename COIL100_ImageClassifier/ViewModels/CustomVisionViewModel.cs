﻿using System.Threading.Tasks;
using Plugin.Media.Abstractions;
using Xamarin.Forms;

using COIL100_ImageClassifier.Services;

namespace COIL100_ImageClassifier.ViewModels
{
    public class CustomVisionViewModel : BaseViewModel
    {
        public Command TakePhotoCommand { get; set; }
        public Command ClassifyPhotoLocalCommand { get; set; }

        private MediaFile photo;

        public MediaFile Photo
        {
            get { return photo; }
            set { photo = value; OnPropertyChanged(); OnPropertyChanged("PhotoStream"); }
        }

        private string classificationResult;

        public string ClassificationResult
        {
            get { return classificationResult; }
            set { classificationResult = value; OnPropertyChanged(); }
        }

        private bool isBusy;

        public bool IsBusy
        {
            get { return isBusy; }
            set { isBusy = value; OnPropertyChanged(); }
        }

        public ImageSource PhotoStream
        {
            get => this.photo != null ? ImageSource.FromStream(photo.GetStreamWithImageRotatedForExternalStorage) : null;
        }

        public CustomVisionViewModel()
        {
            TakePhotoCommand = new Command(async () => await TakePhoto());
            ClassifyPhotoLocalCommand = new Command(async () => await ClassifyPhotoLocal());
        }

        private async Task TakePhoto()
        {
            ClassificationResult = "---";
            Photo = await ImageService.TakePhoto();
        }

        private async Task ClassifyPhotoLocal()
        {
            if (Photo != null)
            {
                IsBusy = true;
                ClassificationResult = "...";
                ClassificationResult = $"Result: {await CustomVisionLocalService.ClassifyImage(photo)}";
                IsBusy = false;
            }
            else
                ClassificationResult = "---No image---";
        }
    }
}