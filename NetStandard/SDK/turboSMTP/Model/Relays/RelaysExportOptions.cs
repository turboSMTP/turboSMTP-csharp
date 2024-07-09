namespace TurboSMTP.Model.Relays
{
    public class RelaysExportOptions : RelaysBaseOptions<RelaysExportOptions, RelaysExportOptions.Builder>
    { 
        public class Builder : RelaysBaseOptions<RelaysExportOptions, Builder>.BaseBuilder
        {
            public Builder() : base(new RelaysExportOptions()) { }
        }
    }
}
