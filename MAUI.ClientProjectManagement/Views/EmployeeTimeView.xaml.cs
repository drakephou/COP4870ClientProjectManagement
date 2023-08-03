using MAUI.ClientProjectManagement.ViewModels;

namespace MAUI.ClientProjectManagement.Views;

public partial class EmployeeTimeView : ContentPage
{
	public EmployeeTimeView()
	{
		InitializeComponent();
        BindingContext = new EmployeeTimeViewModel();
	}

    private void BackButtonClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }

    private void RefreshClicked(object sender, EventArgs e)
    {
        (BindingContext as EmployeeTimeViewModel).Refresh();
    }

    private void AddEmployeeClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//AddEmployee");
    }

    private void EditEmployeeClicked(object sender, EventArgs e)
    {
        if( (BindingContext as EmployeeTimeViewModel).SelectedEmployee != null )
        {
            (BindingContext as EmployeeTimeViewModel).PassSelectedEmployee();
            Shell.Current.GoToAsync("//EditEmployee");
        }

    }
    private void DeleteEmployeeClicked(object sender, EventArgs e)
    {
        (BindingContext as EmployeeTimeViewModel).DeleteEmployee();
    }
    private void AddTimeEntryClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//AddTimeEntry");
    }
    private void EditTimeEntryClicked(object sender, EventArgs e)
    {
        if( (BindingContext as EmployeeTimeViewModel).SelectedTimeEntry != null )
        {
            (BindingContext as EmployeeTimeViewModel).PassSelectedTimeEntry();
            Shell.Current.GoToAsync("//EditTimeEntry");
        }
        
    }
    private void DeleteTimeEntryClicked(object sender, EventArgs e)
    {
        (BindingContext as EmployeeTimeViewModel).DeleteTimeEntry();
    }

    private void OnLeaving(object sender, NavigatedFromEventArgs e)
    {
        BindingContext = null;
    }

    private void OnArriving(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new EmployeeTimeViewModel();
    }
}