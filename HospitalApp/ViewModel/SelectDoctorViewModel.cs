using HospitalApp.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApp.ViewModel
{
    class SelectDoctorViewModel
    {
        SelectDoctorView view = new SelectDoctorView();

        public SelectDoctorViewModel(SelectDoctorView sdv)
        {
            view = sdv;
        }
    }
}
