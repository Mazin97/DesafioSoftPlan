using CompoundCalcApi.Domain.Entities;

namespace CompoundCalcApi.Services.Interfaces
{
    public interface IFeeService
    {
        string CalcCompoundInterest(CompoundCalc calc, double fee);

        Task<double> GetFeeFromApiAsync();
    }
}
