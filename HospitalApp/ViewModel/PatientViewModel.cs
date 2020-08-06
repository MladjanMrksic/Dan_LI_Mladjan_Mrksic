using HospitalApp.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApp.ViewModel
{
    class PatientViewModel : ViewModelBase
    {
        PatientView view;

        public PatientViewModel(PatientView v)
        {
            view = v;
        }
    }
}
