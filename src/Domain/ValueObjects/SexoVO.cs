using Domain.Common;

namespace Domain.ValueObjects
{
    public class SexoVO : ValueObject
    {
        public SexoVO(string value) => Value = value;

        public string Value { get; private set; }

        public static SexoVO Masculino { get { return new SexoVO("M"); } }
        public static SexoVO Feminino { get { return new SexoVO("F"); } }
        public static SexoVO Outros { get { return new SexoVO("O"); } }

        public override string ToString()
        {
            return Value;
        }

        public static IEnumerable<SexoVO> SupportedSexos
        {
            get
            {
                yield return Masculino;
                yield return Feminino;
                yield return Outros;
            }
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
