using System;

namespace CodeReview_HepsiBurada.Objects
{
    public class MyException : Exception
    {
        public MyException(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        public string ErrorMessage { get; set; }
    }
}
