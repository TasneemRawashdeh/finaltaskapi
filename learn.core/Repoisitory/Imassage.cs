using learn.core.Data;
using learn.core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.core.Repoisitory
{
    public interface Imassage
    {
        public List<massage_task> GetAllmassage(); 
        public int countOfmassage();

        public List<massage_task> SearchButweenDate(filtermassagebutwwentwodatedto filter);

        public List<massage_task> FilterMassage(filtermassagess c);
        public massage_task Insertmassage(massage_task mass);
        public List<massage_task> InsertMASSAGEList(massage_task[] massageins);

        public pymentdto GGGG(pymentdto py);

    }
}
