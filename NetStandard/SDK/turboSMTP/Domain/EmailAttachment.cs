using System;
using System.IO;
using System.Text;
using System.Web;

namespace TurboSMTP.Domain
{
    public sealed class EmailAttachment
    {
        private EmailAttachment() { }
        public EmailAttachment(string Base64content, string name, string type)
        {
            this.Content = Base64content;
            this.Name = name;
            this.Type = type;
        }

        public EmailAttachment(string filename, string name = default(string))
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
