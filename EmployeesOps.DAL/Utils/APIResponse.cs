﻿using System.Net;

namespace EmployeesOps.DAL.Utils
{
    public class APIResponse
    {
        public APIResponse()
        {
            ErrorMessages = new List<string>();
            IsSuccess = true;
            StatusCode = HttpStatusCode.OK;
        }
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccess { get; set; } = true;
        public List<string>? ErrorMessages { get; set; }
        public object? Payload { get; set; }


        public APIResponse FailedResponse(HttpStatusCode statusCode, string error)
        {
            this.StatusCode = statusCode;
            this.Payload = null;
            this.IsSuccess = false;
            this.ErrorMessages!.Add(error);

            return this;
        }
    }
}
