using Calculator.Pages;
using Calculator.Services;

namespace Calculator;

public partial class CorrectQuestionPage : ContentPage
{
	public CorrectQuestionPage()
	{
		InitializeComponent();
	}
    public async void navigateToNextQuestion(object sender, EventArgs e)
    {
        var int_num = StorageService.currNum + 1;
        StorageService.setCurrentPage(int_num);
        await SecureStorage.Default.SetAsync("qnum", int_num.ToString());
        await Navigation.PushAsync(new APITestPage());
    }

}
