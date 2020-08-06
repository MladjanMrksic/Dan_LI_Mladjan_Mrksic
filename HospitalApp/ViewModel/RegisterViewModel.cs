using HospitalApp.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApp.ViewModel
{
    class RegisterViewModel : ViewModelBase
    {
        RegisterView view;

        public RegisterViewModel(RegisterView v)
        {
            view = v;
        }
    }
}
