using Words.ViewModels;

namespace Words.Views;

public partial class WordsBoardView : ContentPage
{
	public WordsBoardView(WordsBoardViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}
}

