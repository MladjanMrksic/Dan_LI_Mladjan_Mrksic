using HospitalApp.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApp.ViewModel
{
    class LoginViewModel : ViewModelBase
    {
        LoginView view;

        public LoginViewModel(LoginView v)
        {
            view = v;
        }
    }
}
