using MAUI.ClientProjectManagement.ViewModels;

namespace MAUI.ClientProjectManagement.Views;

public partial class EditEmployeeView : ContentPage
{
	public EditEmployeeView()
	{
		InitializeComponent();
		BindingContext = new EditEmployeeViewModel();
	}

    private void BackButtonClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//EmployeeTime");
    }

    private void EnterClicked(object sender, EventArgs e)
    {
        (BindingContext as EditEmployeeViewModel).EditEmployee();
        Shell.Current.GoToAsync("//EmployeeTime");
    }

    private void OnLeaving(object sender, NavigatedFromEventArgs e)
    {
        BindingContext = null;
    }

    private void OnArriving(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new EditEmployeeViewModel();
    }
}