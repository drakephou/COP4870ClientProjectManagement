using MAUI.ClientProjectManagement.ViewModels;

namespace MAUI.ClientProjectManagement.Views;

public partial class EditClientView : ContentPage
{
	public EditClientView()
	{
		InitializeComponent();
        BindingContext = new EditClientViewModel();
	}
    private void BackButtonClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//ClientProject");
    }

    private void EnterClicked(object sender, EventArgs e)
    {
        (BindingContext as EditClientViewModel).EditClient();
        Shell.Current.GoToAsync("//ClientProject");
    }



    private void OnLeaving(object sender, NavigatedFromEventArgs e)
    {
        BindingContext = null;
    }

    private void OnArriving(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new EditClientViewModel();
    }
}