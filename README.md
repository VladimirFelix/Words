# Words
Find words horizontally and vertically in a matrix

Simple MAUI app to search words horizontally and vertically in a matrix
This app needs .Net MAUI dependencies installed

UI: 
Search: Find words in the matrix clicking the button.
Results: App shows results in right side.

![image](https://github.com/VladimirFelix/Words/assets/5857023/578441a2-4868-434f-b9e1-5765757dea8c)

App showing results from document test words, also I added the time that apps takes to get the words.

![image](https://github.com/VladimirFelix/Words/assets/5857023/efcd4203-3113-4ee6-874c-88e47fd92b96)

To edit the values of the matrix or the words to find is needed to edit the data in the following methods inside the folder "Helpers" in the "TestData.cs" file.
Now is with the original data of the exersise.

    public static List<string> GetExerciseItems()
        {
            return new List<string>
            {
                "ABCDC",
                "FGWIO",
                "CHILL",
                "PQNSD",
                "UVDXY"
            };
        }

        public static List<string> GetExerciseWordsToFind()
        {
            return new List<string>()
            {
                "cold",
                "wind",
                "snow",
                "chill"
            };
        }
