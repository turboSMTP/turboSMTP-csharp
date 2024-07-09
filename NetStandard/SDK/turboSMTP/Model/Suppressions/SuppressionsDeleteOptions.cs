using TurboSMTP.Model.Shared;

namespace TurboSMTP.Model.Suppressions
{
    public class SuppressionsDeleteOptions : SuppressionsBaseOptions<SuppressionsDeleteOptions,SuppressionsDeleteOptions.Builder>
    { 
        public class Builder : SuppressionsBaseOptions<SuppressionsDeleteOptions,Builder>.BaseBuilder
        {
            public Builder() : base(new SuppressionsDeleteOptions()) { }
        }
    }
}
