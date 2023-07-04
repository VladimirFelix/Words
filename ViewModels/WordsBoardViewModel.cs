using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using Words.Exceptions;
using Words.Helpers;
using Words.Services;

namespace Words.ViewModels
{
    public partial class WordsBoardViewModel : ObservableObject
    {
        private WordFinder wordFinder = null;
        private List<string> words;
        private List<string> wordsToFind;

        public WordsBoardViewModel()
        {
            LoadDefaultValues();
        }

        [ObservableProperty]
        ObservableCollection<string> results;

        [ObservableProperty]
        string resultText;

        [RelayCommand]
        void ShowResults()
        {
            try
            {
                wordFinder = new WordFinder(words);

                var startDate = DateTime.Now;
                var results = wordFinder.Find(wordsToFind);
                var endDate = DateTime.Now;

                if (results.Any())
                {
                    Results = new ObservableCollection<string>(results);
                    ResultText = $"{Results.Count} words found in {(long)(endDate - startDate).TotalMilliseconds} miliseconds";
                }
                else
                    ResultText = "No words found";

            }
            catch (ArgumentNullException nullEx)
            {
                App.Current.MainPage.DisplayAlert("", nullEx.Message, "Ok");
            }
            catch(InvalidMatrixLengthException invalidMatrixEx)
            {
                App.Current.MainPage.DisplayAlert("", invalidMatrixEx.Message, "Ok");
            }
        }

        private void LoadDefaultValues()
        {
            words = TestData.GetExerciseItems();
            wordsToFind = TestData.GetExerciseWordsToFind();
        }
    }
}