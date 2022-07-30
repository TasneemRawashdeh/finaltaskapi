using learn.core.Data;
using learn.core.Repoisitory;
using learn.core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.infra.Service
{
    public class countryService : IcountryService
    {
        private readonly Icountry country_taskrepo;
        public countryService(Icountry country_taskrepo)
        {
            this.country_taskrepo = country_taskrepo;
        }
        public bool Deletecountry(int? conId)
        {
            return country_taskrepo.Deletecountry(conId);
        }

        public List<country_task> GetAllcountry()
        {
            return country_taskrepo.GetAllcountry();
        }

        public country_task Insertcountry(country_task country)
        {
            return country_taskrepo.Insertcountry(country);
        }

        public bool Updatecountry(country_task country)
        {
            return country_taskrepo.Updatecountry(country);
        }
    }
}
