using learn.core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.core.Repoisitory
{
  public interface IAuthentication
    {
        public login_task auth(login_task login);

    }
}
