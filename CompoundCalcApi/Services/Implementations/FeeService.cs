using CompoundCalcApi.Domain.Entities;
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

        public string CalcCompoundInterest(CompoundCalc calc, double fee)
        {
            return Math.Round(calc.Calculate(fee), 2, MidpointRounding.ToZero).ToString("F");
        }

        public async Task<double> GetFeeFromApiAsync()
        {
            try
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
            catch (Exception)
            {
                return 0.01F; // default fee value
            }
        }
    }
}
