namespace CompoundCalcApi.Services.Interfaces
{
    public interface IFeeService
    {
        Task<string> CalcCompoundInterestAsync(double initialValue, int monthsQuantity);
    }
}
