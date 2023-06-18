namespace MAUI.ClientProjectManagement
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            //BindingContext = new MainViewModel();
        }
        

        private void ClientProjectClicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//ClientProject");
        }

        private void EmployeeTimeClicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//EmployeeTime");
        }
    }
}