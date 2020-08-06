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
    class RegisterViewModel : ViewModelBase
    {
        RegisterView view;

        PatientModel patientMod = new PatientModel();
        DoctorModel doctorMod = new DoctorModel();

        public RegisterViewModel(RegisterView v)
        {
            view = v;
            Doctor = new Doctor();
            Patient = new Patient();
        }

        private Doctor doctor;
        public Doctor Doctor
        {
            get { return doctor; }
            set
            {
                doctor = value;
                OnPropertyChanged("Doctor");
            }
        }

        private Patient patient;
        public Patient Patient
        {
            get { return patient; }
            set { patient = value; OnPropertyChanged("Patient"); }
        }

        private ICommand createPatient;
        public ICommand CreatePatient
        {
            get
            {
                if (createPatient == null)
                {
                    createPatient = new RelayCommand(param => CreatePatientExecute(), param => CanCreatePatientExecute());
                }
                return createPatient;
            }
        }
        private void CreatePatientExecute()
        {
            view.txtPatientFirstName.Visibility = System.Windows.Visibility.Visible;
            view.txtPatientLastName.Visibility = System.Windows.Visibility.Visible;
            view.txtPatientJMBG.Visibility = System.Windows.Visibility.Visible;
            view.txtPatientHealthInsuranceCardNumber.Visibility = System.Windows.Visibility.Visible;
            view.txtPatientUsername.Visibility = System.Windows.Visibility.Visible;
            view.txtPatientPassword.Visibility = System.Windows.Visibility.Visible;

            view.txtDoctorFirstName.Visibility = System.Windows.Visibility.Hidden;
            view.txtDoctorLastName.Visibility = System.Windows.Visibility.Hidden;
            view.txtDoctorJMBG.Visibility = System.Windows.Visibility.Hidden;
            view.txtDoctorBankAccountNumber.Visibility = System.Windows.Visibility.Hidden;
            view.txtDoctorUsername.Visibility = System.Windows.Visibility.Hidden;
            view.txtDoctorPassword.Visibility = System.Windows.Visibility.Hidden;

            view.lblPatientHICN.Visibility = System.Windows.Visibility.Visible;
            view.lblDoctorBAN.Visibility = System.Windows.Visibility.Hidden;

            view.btnSaveDoctor.Visibility = System.Windows.Visibility.Hidden;
            view.btnSavePatient.Visibility = System.Windows.Visibility.Visible;
        }
        private bool CanCreatePatientExecute()
        {
            return true;
        }

        private ICommand createDoctor;
        public ICommand CreateDoctor
        {
            get
            {
                if (createDoctor == null)
                {
                    createDoctor = new RelayCommand(param => CreateDoctorExecute(), param => CanCreateDoctorExecute());
                }
                return createDoctor;
            }
        }
        private void CreateDoctorExecute()
        {
            view.txtPatientFirstName.Visibility = System.Windows.Visibility.Hidden;
            view.txtPatientLastName.Visibility = System.Windows.Visibility.Hidden;
            view.txtPatientJMBG.Visibility = System.Windows.Visibility.Hidden;
            view.txtPatientHealthInsuranceCardNumber.Visibility = System.Windows.Visibility.Hidden;
            view.txtPatientUsername.Visibility = System.Windows.Visibility.Hidden;
            view.txtPatientPassword.Visibility = System.Windows.Visibility.Hidden;

            view.txtDoctorFirstName.Visibility = System.Windows.Visibility.Visible;
            view.txtDoctorLastName.Visibility = System.Windows.Visibility.Visible;
            view.txtDoctorJMBG.Visibility = System.Windows.Visibility.Visible;
            view.txtDoctorBankAccountNumber.Visibility = System.Windows.Visibility.Visible;
            view.txtDoctorUsername.Visibility = System.Windows.Visibility.Visible;
            view.txtDoctorPassword.Visibility = System.Windows.Visibility.Visible;

            view.lblPatientHICN.Visibility = System.Windows.Visibility.Hidden;
            view.lblDoctorBAN.Visibility = System.Windows.Visibility.Visible;

            view.btnSaveDoctor.Visibility = System.Windows.Visibility.Visible;
            view.btnSavePatient.Visibility = System.Windows.Visibility.Hidden;
        }
        private bool CanCreateDoctorExecute()
        {
            return true;
        }

        private ICommand savePatient;
        public ICommand SavePatient
        {
            get
            {
                if (savePatient == null)
                {
                    savePatient = new RelayCommand(param => SavePatientExecute(), param => CanSavePatientExecute());
                }
                return savePatient;
            }
        }
        private void SavePatientExecute()
        {
            patientMod.AddPatient(Patient);
            view.Close();
        }
        private bool CanSavePatientExecute()
        {
            return true;
        }

        private ICommand saveDoctor;
        public ICommand SaveDoctor
        {
            get
            {
                if (saveDoctor == null)
                {
                    saveDoctor = new RelayCommand(param => SaveDoctorExecute(), param => CanSaveDoctorExecute());
                }
                return saveDoctor;
            }
        }
        private void SaveDoctorExecute()
        {
            doctorMod.AddDoctor(Doctor);
            view.Close();
        }
        private bool CanSaveDoctorExecute()
        {
            return true;
        }
    }
}
