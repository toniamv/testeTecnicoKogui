namespace AplicativoTesteTecnicoKogui
{
    public partial class App : Application
    {
        public App(IServiceProvider sp)
        {
            InitializeComponent();
            MainPage = sp.GetRequiredService<MainPage>();
        }
    }
}
