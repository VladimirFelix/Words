namespace Words.Exceptions
{
    internal class InvalidMatrixLengthException : Exception
    {
        public override string Message => "The Matrix must have the same number of characters horizontally and vertically";
    }
}