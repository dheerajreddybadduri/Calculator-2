using Calculator.Services;

namespace Calculator.Pages;

public partial class APITestPage : ContentPage
{
    public int questionNumber = 0;
    public string correctOptionValue;
    public APITestPage()
	{
		InitializeComponent();
        loadSavedQuestionNumber();
        updateQuestionData();
	}

    public void loadSavedQuestionNumber()
    {
        questionNumber = StorageService.currNum;
    }

    public void goToNextQuestion()
    {
        ++questionNumber;
        updateQuestionData();
    }

    public async void updateQuestionData()
    {
        TestAPIService api = new TestAPIService();
        var questionData = await api.getTestQuestion(questionNumber);
        questionText.Text = questionData.questionText;
        optionOneBtn.Text = questionData.optionOne;
        optionTwoBtn.Text = questionData.optionTwo;
        optionThreeBtn.Text = questionData.optionThree;
        correctOptionValue = questionData.correctOptionValue;
    }

    private async void renderResults(String actualAns)
    {
        if(optionOneBtn.Text == actualAns)
        {
            optionOneBtn.BackgroundColor = Colors.Green;
            optionTwoBtn.BackgroundColor = Colors.Red;
            optionThreeBtn.BackgroundColor = Colors.Red;
        }
        if (optionTwoBtn.Text == actualAns)
        {
            optionTwoBtn.BackgroundColor = Colors.Green;
            optionThreeBtn.BackgroundColor = Colors.Red;
            optionOneBtn.BackgroundColor = Colors.Red;

        }
        if (optionThreeBtn.Text == actualAns)
        {
            optionThreeBtn.BackgroundColor = Colors.Green;
            optionOneBtn.BackgroundColor = Colors.Red;
            optionTwoBtn.BackgroundColor = Colors.Red;

        }
    }

    
}
