namespace CompoundCalcApi.Domain.Entities
{
    public class CompoundCalc
    {
        public CompoundCalc(double initialValue, int months)
        {
            InitialValue = initialValue;
            Months = months;
        }

        public double InitialValue { get; private set; }

        public int Months { get; private set; }

        public double Calculate(double fee)
        {
            var mensalCompound = 1 + fee;
            var result = InitialValue;

            for (int i = 0; i < Months; i++)
                result *= mensalCompound;

            return result;
        }
    }
}
