using HospitalApp.Command;
using HospitalApp.Model;
using HospitalApp.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HospitalApp.ViewModel
{
    class DoctorViewModel : ViewModelBase
    {
        DoctorView view;
        SickLeaveModel slMod = new SickLeaveModel();
        public DoctorViewModel(DoctorView v,Doctor d)
        {
            view = v;
            Doctor = d;
            SickLeaveList = slMod.GetAllSickLeavesByDoctorID(d.DoctorID);
        }

        private Doctor doctor;

        public Doctor Doctor
        {
            get { return doctor; }
            set { doctor = value; OnPropertyChanged("Doctor"); }
        }

        private List<SickLeave> sickLeaveList;

        public List<SickLeave> SickLeaveList
        {
            get { return sickLeaveList; }
            set { sickLeaveList = value; OnPropertyChanged("SickLeaveList"); }
        }

        private SickLeave sickLeave;

        public SickLeave SickLeave
        {
            get { return sickLeave; }
            set { sickLeave = value; OnPropertyChanged("SickLeave"); }
        }

        private ICommand logout;
        public ICommand Logout
        {
            get
            {
                if (logout == null)
                {
                    logout = new RelayCommand(param => LogoutExecute(), param => CanLogoutExecute());
                }
                return logout;
            }
        }
        private void LogoutExecute()
        {
            LoginView logout = new LoginView();
            view.Close();
            logout.Show();
        }
        private bool CanLogoutExecute()
        {
            return true;
        }
    }
}
