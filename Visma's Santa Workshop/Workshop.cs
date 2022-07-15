using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visma_s_Santa_Workshop
{
    public class Workshop : IEquatable<Workshop>
    {
        public string? Children_FullName;
        public string? Gift_Name;

        public string Name
        {

            get
            {
                return Children_FullName;
            }

            set
            {
                Children_FullName = value;
            }

        }

        public string Gift
        {

            get
            {
                return Gift_Name;
            }

            set
            {
                Gift_Name = value;
            }

        }

        public Workshop(string children_FullName, string gift_Name)
        {
            Children_FullName=children_FullName;
            Gift_Name=gift_Name;
        }

        public bool Equals(Workshop other)
        {
            if (this.Children_FullName == other.Children_FullName)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            return string.Format("|{0,-25}|{1,35}|", this.Children_FullName, this.Gift_Name);
        }
        public string ToFile()
        {
            return string.Format($"{Children_FullName};{Gift_Name}");
        }
    }
}