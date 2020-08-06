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
    class PatientViewModel : ViewModelBase
    {
        PatientView view;
        SickLeaveModel slMod = new SickLeaveModel();
        public PatientViewModel(PatientView v,Patient p)
        {
            view = v;
            Patient = p;
            SickLeaveList = slMod.GetAllSickLeavesByPatientID(p.PatientID);
        }

        private Patient patient;

        public Patient Patient
        {
            get { return patient; }
            set { patient = value; OnPropertyChanged("Patient"); }
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
