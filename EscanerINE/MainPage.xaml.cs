namespace EscanerINE
{
    public partial class MainPage : ContentPage
    {
        

        private List<ImageSource> _capturedPhotos;

        public MainPage()
        {
            InitializeComponent();
            _capturedPhotos = new List<ImageSource>();
        }

        private async Task CaptureMultiplePhotos(int count)
        {
            for (int i = 0; i < count; i++)
            {
                var photo = await MediaPicker.CapturePhotoAsync();
                if (photo != null)
                {
                    var memoryStream = await photo.OpenReadAsync();
                    var imageSource = ImageSource.FromStream(() => memoryStream);
                    _capturedPhotos.Add(imageSource);
                }
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await CaptureMultiplePhotos(3);

            // Mostrar las imágenes capturadas en la interfaz de usuario
            if (_capturedPhotos.Count > 0)
            {
                foreach (var photo in _capturedPhotos)
                {
                    // Aquí puedes agregar las fotos a una colección o mostrarlas en la pantalla
                    var image = new Image { Source = photo };
                    imgsFotos.Children.Add(image); // Reemplaza "YourStackLayout" con tu contenedor
                }
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
