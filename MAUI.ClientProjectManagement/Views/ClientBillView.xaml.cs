using Library.ClientProjectManagement.Models;
using MAUI.ClientProjectManagement.ViewModels;

namespace MAUI.ClientProjectManagement.Views;

[QueryProperty(nameof(ClientId), "clientId")]
public partial class ClientBillView : ContentPage
{
	public int ClientId { get; set; }
	public ClientBillView()
	{
		InitializeComponent();
	}

    private void OnLeaving(object sender, NavigatedFromEventArgs e)
    {
        BindingContext = null;
    }

    private void OnArriving(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new ClientBillViewModel(ClientId);
    }

    private void BackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//ClientProject");
    }
}