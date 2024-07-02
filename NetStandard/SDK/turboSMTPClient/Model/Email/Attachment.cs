using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace TurboSMTPSDK.Model.Email
{
    public sealed class Attachment
    {
        private Attachment() { }
        public Attachment(string Base64content, string name, string type)
        {
            this.Content = Base64content;
            this.Name = name;
            this.Type = type;
        }

        public Attachment(string filename, string name = default(string))
        {
            Content = Convert.ToBase64String(File.ReadAllBytes(filename));
            Name = !String.IsNullOrEmpty(name) ? name : Path.GetFileName(filename);
            Type = MimeMapping.GetMimeMapping(filename);
        }

        public String Content { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class Attachment {\n");
            sb.Append("  Content: ").Append(Content).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
    }
}
