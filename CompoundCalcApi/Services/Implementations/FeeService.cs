using CompoundCalcApi.Services.Interfaces;

namespace CompoundCalcApi.Services.Implementations
{
    public class FeeService : IFeeService
    {
        private readonly IConfiguration _configuration;

        public FeeService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<string> CalcCompoundInterestAsync(double initialValue, int monthsQuantity)
        {
            var fee = await GetFeeFromApiAsync();
            var mensalCompound = 1 + fee;

            for (int i = 0; i < monthsQuantity; i++)
                initialValue *= mensalCompound;

            return Math.Round(initialValue, 2, MidpointRounding.ToZero).ToString("F");
        }

        private async Task<double> GetFeeFromApiAsync()
        {
            var feeApiUrl = _configuration["FeeApiUrl"];
            if (string.IsNullOrEmpty(feeApiUrl)) throw new ArgumentException("Fee Api URL was required.");

            using var client = new HttpClient();
            var response = await client.SendAsync(new HttpRequestMessage
            {
                RequestUri = new Uri(feeApiUrl)
            });

            if (response == null || !response.IsSuccessStatusCode || !double.TryParse(await response.Content.ReadAsStringAsync(), out double fee))
                throw new ArgumentException("Fail to recover fee value");

            return fee;
        }
    }
}
