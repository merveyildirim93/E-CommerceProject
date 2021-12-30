using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Api.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string message = null)
        {
            this.StatusCode = statusCode;
            this.Message = message ?? GetDefaultMessage(statusCode);
        }
        private string GetDefaultMessage(int statusCode)
        {
            string errorMessage = string.Empty;
            switch (statusCode)
            {
                case 400:
                    errorMessage = "A Bad request!";
                    break;
                case 401:
                    errorMessage = "Authorized error!";
                    break;
                case 404:
                    errorMessage = "Resources Not Found!";
                    break;
                case 500:
                    errorMessage = "Server Error!";
                    break;
            }
            return errorMessage;
        }
        public int StatusCode { get; set; }
        public string Message { get; set; }

    }
}
