using Windows.UI.Core;
using Windows.UI.Xaml.Navigation;
using Music_Trainer.ViewModel;

namespace Music_Trainer
{
    public sealed partial class MainPage
    {
        public MainViewModel Vm => (MainViewModel)DataContext;

        public MainPage()
        {
            InitializeComponent();

            SystemNavigationManager.GetForCurrentView().BackRequested += SystemNavigationManagerBackRequested;

            Loaded += (s, e) =>
            {
                Vm.RunClock();
            };

            var wav = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Soundbank/Guitar/shit.mp3"));
            var player = new AudioPlayer();
            await player.LoadFileAsync(wav);
            player.Play("shit.mp3", 0.5);
        }

        private void SystemNavigationManagerBackRequested(object sender, BackRequestedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                e.Handled = true;
                Frame.GoBack();
            }
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            Vm.StopClock();
            base.OnNavigatingFrom(e);
        }
    }
}
