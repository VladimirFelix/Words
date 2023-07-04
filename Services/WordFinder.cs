using Words.Exceptions;

namespace Words.Services
{
    public class WordFinder
    {
        public WordFinder(IEnumerable<string> matrix)
        {
            ValidateMatrixCharacterLength(matrix);
            this.matrix = matrix;
        }

        private IEnumerable<string> matrix = null;

        private void ValidateMatrixCharacterLength(IEnumerable<string> matrix)
        {
            if (matrix == null || !matrix.Any())
                throw new ArgumentNullException(nameof(matrix));

            if (matrix.Count() > 64)
                throw new MaximumMatrixException();

            var isMatrixValid = from row in matrix
                                where row.Count() != matrix.Count()
                                select true;

            var isInvalid = isMatrixValid.Any(a => a);

            if (isInvalid)
                throw new InvalidMatrixLengthException();
        }

        public IEnumerable<string> Find(IEnumerable<string> wordstream)
        {
            List<string> foundWords = new List<string>();

            foundWords.AddRange(GetHorizontallyWords(wordstream));

            foundWords.AddRange(GetVerticallyWords(wordstream));           

            return foundWords.Distinct().Take(10);
        }

        private IEnumerable<string> GetVerticallyWords(IEnumerable<string> wordstream)
        {
            var itemCount = 0;
            List<string> words = new List<string>();
            while (itemCount < matrix.Count())
            {
                var word = from matrixItem in matrix
                           from charItem in matrixItem[itemCount].ToString()
                           select charItem;

                var mianWord = new string(word.ToArray());

                var verticalQuery = from searchWord in wordstream
                                    where mianWord.ToLower().Contains(searchWord.ToLower())
                                    select searchWord;

                words.AddRange(verticalQuery);

                itemCount++;
            }
            return words;
        }

        private IEnumerable<string> GetHorizontallyWords(IEnumerable<string> wordstream)
        {
            var horizontalQuery = from rows in matrix
                                  from word in wordstream
                                  where rows.ToLower().Contains(word.ToLower())
                                  select word;

            return horizontalQuery;
        }
    }
}