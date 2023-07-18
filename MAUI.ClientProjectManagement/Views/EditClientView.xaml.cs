using MAUI.ClientProjectManagement.ViewModels;

namespace MAUI.ClientProjectManagement.Views;

[QueryProperty(nameof(ClientId), "clientId")]
public partial class EditClientView : ContentPage
{
    public int ClientId { get; set; }
	public EditClientView()
	{
		InitializeComponent();
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
        BindingContext = new EditClientViewModel(ClientId);
    }
}