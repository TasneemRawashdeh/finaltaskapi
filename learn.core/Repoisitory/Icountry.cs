using learn.core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.core.Repoisitory
{
    public interface Icountry
    {
        public List<country_task> GetAllcountry();
        public country_task Insertcountry(country_task country);
        public bool Updatecountry(country_task country);
        public bool Deletecountry(int? conId);

       

    }
}
