using Xamarin.Forms;

namespace COIL100_ImageClassifier
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Views.CustomVisionView();
        }
    }
}
