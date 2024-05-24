using Domain.Common;

namespace Domain.ValueObjects
{
    public class SimNaoVO : ValueObject
    {
        public SimNaoVO(string value) => Value = value;

        public string Value { get; private set; }

        public static SimNaoVO Sim { get { return new SimNaoVO("S"); } }
        public static SimNaoVO Nao { get { return new SimNaoVO("N"); } }

        public override string ToString()
        {
            return Value;
        }

        public static IEnumerable<SimNaoVO> SupportedOptions
        {
            get
            {
                yield return Sim;
                yield return Nao;
            }
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
