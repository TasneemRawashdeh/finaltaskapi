using learn.core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.core.Service
{
    public interface IAuthenticationservice
    {
        public string Authentication_jwt(login_task login);

    }
}
