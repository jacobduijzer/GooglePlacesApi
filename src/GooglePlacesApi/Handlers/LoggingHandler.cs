using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using GooglePlacesApi.Abstractions.Interfaces;
using GooglePlacesApi.Loggers;

namespace GooglePlacesApi.Handlers
{
    public class LoggingHandler : DelegatingHandler
    {
        private readonly IRefitLogger _logger;

        public LoggingHandler(HttpMessageHandler innerHandler)
            : base(innerHandler)
        {
            if(_logger == null)
                _logger = new ConsoleLogger();
        }

        public LoggingHandler(HttpMessageHandler innerHandler, IRefitLogger logger)
            : base(innerHandler)
        => _logger = logger;

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            _logger.Write("Request:");
            _logger.Write(request.ToString());
            if (request.Content != null)
            {
                _logger.Write(await request.Content.ReadAsStringAsync());
            }
            _logger.Write(Environment.NewLine);

            HttpResponseMessage response = await base.SendAsync(request, cancellationToken);

            _logger.Write("Response:");
            _logger.Write(response.ToString());
            if (response.Content != null)
            {
                _logger.Write(await response.Content.ReadAsStringAsync());
            }
            _logger.Write(Environment.NewLine);

            return response;
        }
    }
}
