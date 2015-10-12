using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core
{
    public class Customer
    {
        public virtual string CustomerId { get; set; }
        public virtual string CompanyName { get; set; }
        public virtual string ContactName { get; set; }
        public virtual string ContactTitle { get; set; }
        public virtual string Address { get; set; }
        public virtual string City { get; set; }
        public virtual string Region { get; set; }
        public virtual string PostalCode { get; set; }
        public virtual string Country { get; set; }
        public virtual string Phone { get; set; }
        public virtual string Fax { get; set; }
        public string ToHtml(string CssClass)
        {
            var sb = new StringBuilder();
            if (CssClass.Length == 0)
                sb.Append("<div>");
            else
            {
                sb.AppendFormat("<div class='{0}'>", CssClass);
            }
            sb.AppendFormat("<div><span>Company:</span><span>{0}</span></div>", CompanyName);
            sb.AppendFormat("<div><span>Your Title:</span><span>{0}</span></div>", ContactTitle);
            sb.AppendFormat("<div><span>Address:</span><span>{0}</span></div>", Address);
            sb.AppendFormat("<div><span>City:</span><span>{0}</span></div>", City);
            sb.AppendFormat("<div><span>State/region:</span><span>{0}</span></div>", Region);
            sb.AppendFormat("<div><span>Zipcode/postal code:</span><span>{0}</span></div>", PostalCode);
            sb.AppendFormat("<div><span>Country:</span><span>{0}</span></div>", Country);
            sb.Append("</div>");
            return sb.ToString();
        }
        public string ToHtml()
        {
            return ToHtml("");
        }
    }
}
