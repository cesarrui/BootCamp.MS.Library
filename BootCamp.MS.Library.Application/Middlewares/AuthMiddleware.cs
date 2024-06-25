using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.Functions.Worker.Middleware;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BootCamp.MS.Library.Application
{
    public class AuthMiddleware : IFunctionsWorkerMiddleware
    {
        private readonly HttpClient _httpClient;
        private readonly string _validateTokenFunctionUrl;
        public AuthMiddleware(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _validateTokenFunctionUrl = configuration["ValidateTokenFunctionUrl"]!;
        }
        public async Task Invoke(FunctionContext context, FunctionExecutionDelegate next)
        {
            var httpReqData = await context.GetHttpRequestDataAsync();

            if (httpReqData!.Headers.TryGetValues("Authorization", out var authHeaders))
            {
                var token = authHeaders.FirstOrDefault()?.Substring("Bearer ".Length).Trim();

                if (!string.IsNullOrEmpty(token))
                {
                    var validateResponse = await _httpClient.PostAsync(_validateTokenFunctionUrl, new StringContent(token));

                    if (validateResponse.IsSuccessStatusCode)
                    {
                        await next(context);
                        return;
                    }
                }
            }

            if (httpReqData != null)
            {
                var newHttpResponse = httpReqData.CreateResponse(HttpStatusCode.Unauthorized);

                await newHttpResponse.WriteAsJsonAsync(new { Status = "Unauthorized!" }, newHttpResponse.StatusCode);

                var invocationResult = context.GetInvocationResult();

                invocationResult.Value = newHttpResponse;
            }

        }
    }
}
