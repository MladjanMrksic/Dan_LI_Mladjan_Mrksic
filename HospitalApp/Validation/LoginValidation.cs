using HospitalApp.Model;
using HospitalApp.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HospitalApp.Validation
{
    class LoginValidation
    {
        public void Login(string username, string password, LoginView view)
        {
            PatientModel patient = new PatientModel();
            DoctorModel doctor = new DoctorModel();

            List<Patient> patients = patient.GetAllPatients();
            List<Doctor> doctors = doctor.GetAllDoctors();
            if (patients.Contains((from x in patients where x.Username == username && x.Password == password select x).FirstOrDefault()))
            {
                PatientView pv = new PatientView();
                view.Close();
                pv.Show();
            }
            else if (doctors.Contains((from x in doctors where x.Username == username && x.Password == password select x).FirstOrDefault()))
            {
                DoctorView dv = new DoctorView();
                view.Close();
                dv.Show();
            }
            else
            {
                MessageBox.Show("Incorrect password or username. Please try again.", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
    }
}
