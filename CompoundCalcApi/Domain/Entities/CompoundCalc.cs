using Flunt.Notifications;
using Flunt.Validations;

namespace CompoundCalcApi.Domain.Entities
{
    public class CompoundCalc : Notifiable
    {
        public CompoundCalc(double initialValue, int months)
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsGreaterThan(months, 0, "fee", "Período é menor que o período mínimo permitido.")
            );

            InitialValue = initialValue;
            Months = months;
        }

        public double InitialValue { get; private set; }

        public int Months { get; private set; }

        private readonly int _mensalCompoundBase = 1;

        public double Calculate(double fee)
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsGreaterThan(fee, 0, "fee", "Taxa inválida")
            );

            var mensalCompound = _mensalCompoundBase + fee;
            var result = InitialValue;

            for (int i = 0; i < Months; i++)
                result *= mensalCompound;

            return result;
        }
    }
}
