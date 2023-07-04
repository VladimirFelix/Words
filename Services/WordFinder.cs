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


            var horizontalQuery = from rows in matrix
                                  from word in wordstream
                                  where rows.ToLower().Contains(word.ToLower())
                                  select word;

            foundWords.AddRange(horizontalQuery);

            var itemCount = 0;
            while (itemCount < matrix.Count())
            {
                var word = from item in matrix
                           from wi in item[itemCount].ToString()
                           select wi;

                var palabra = new string(word.ToArray());

                var verticalQuery = 
                                    from stream in wordstream
                                    where palabra.ToString().ToLower().Contains(stream.ToLower())
                                    select stream;

                foundWords.AddRange(verticalQuery);


                itemCount++;
            }

            return foundWords.Distinct().Take(10);
        }
    }
}