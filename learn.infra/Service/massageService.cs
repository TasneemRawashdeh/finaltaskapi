using learn.core.Data;
using learn.core.DTO;
using learn.core.Repoisitory;
using learn.core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.infra.Service
{
    public class massageService : IMassageService
    {
        private readonly Imassage massage_taskrepo;
        public massageService(Imassage massage_taskrepo)
        {
            this.massage_taskrepo = massage_taskrepo;
        }
        public int countOfmassage()
        {
            return massage_taskrepo.countOfmassage();
        }

        public List<massage_task> GetAllmassage()
        {
            return massage_taskrepo.GetAllmassage();
        }

        public List<massage_task> SearchButweenDate(filtermassagebutwwentwodatedto filter)
        {
            return massage_taskrepo.SearchButweenDate(filter);
        }

        public List<massage_task> FilterMassage(filtermassagess c)
        {

            return massage_taskrepo.FilterMassage(c);
        }

        public massage_task Insertmassage(massage_task mass)
        {
            return massage_taskrepo.Insertmassage(mass);
        }

        public List<massage_task> InsertMASSAGEList(massage_task[] massageins)
        {
            return massage_taskrepo.InsertMASSAGEList(massageins);
        }


        public pymentdto GGGG(pymentdto py)
        {
          return  massage_taskrepo.GGGG(py);
        }
        }
    }
