using MAUI.ClientProjectManagement.ViewModels;

namespace MAUI.ClientProjectManagement.Views;

public partial class AddClientView : ContentPage
{
    public AddClientView()
    {
        InitializeComponent();
        BindingContext = new AddClientViewModel();
    }

    private void BackButtonClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//ClientProject");
    }

    private void EnterClicked(object sender, EventArgs e)
    {
        (BindingContext as AddClientViewModel).AddClient();
        Shell.Current.GoToAsync("//ClientProject");
    }

    private void OnLeaving(object sender, NavigatedFromEventArgs e)
    {
        BindingContext = null;
    }

    private void OnArriving(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new AddClientViewModel();
    }

}