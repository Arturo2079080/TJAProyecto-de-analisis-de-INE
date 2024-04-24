namespace EscanerINE
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            var foto = await MediaPicker.CapturePhotoAsync();

            if (foto != null)
            {
                var memoriaStream = await foto.OpenReadAsync();
                imgFoto.Source = ImageSource.FromStream(() => memoriaStream);
            }

        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            var foto = await MediaPicker.PickPhotoAsync();

            if (foto != null)
            {
                var memoriaStream = await foto.OpenReadAsync();
                imgFoto.Source = ImageSource.FromStream(() => memoriaStream);
            }

        }
    }

}
