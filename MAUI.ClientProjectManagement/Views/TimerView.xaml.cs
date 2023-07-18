using MAUI.ClientProjectManagement.ViewModels;

namespace MAUI.ClientProjectManagement.Views;

public partial class TimerView : ContentPage
{
	public TimerView(int projectId)
	{
		InitializeComponent();
		BindingContext = new TimerViewModel(projectId);
	}
}