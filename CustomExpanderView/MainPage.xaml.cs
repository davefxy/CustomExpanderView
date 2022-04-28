using CustomExpanderView.Models;

namespace CustomExpanderView;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
		BindingContext = new MainPageViewModel();
	}

    private void Item_OnTapped(object sender, EventArgs e)
    {
		var view = (Label)sender;
		var gesture = view.GestureRecognizers.First(x => x is TapGestureRecognizer) as TapGestureRecognizer;
		var model = gesture.CommandParameter;
	}
}

