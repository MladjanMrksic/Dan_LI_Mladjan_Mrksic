using HospitalApp.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApp.ViewModel
{
    class DoctorViewModel : ViewModelBase
    {
        DoctorView view;

        public DoctorViewModel(DoctorView v)
        {
            view = v;
        }
    }
}
