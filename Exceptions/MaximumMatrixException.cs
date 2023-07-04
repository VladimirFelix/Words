namespace Words.Exceptions
{
    internal class MaximumMatrixException : Exception
    {
        public override string Message => "Maximum size of the matrix is 64x64.";
    }
}