using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HospitalApp.Model
{
    class PatientModel
    {
        public List<Patient> GetAllPatients()
        {
            try
            {
                using (HospitalDatabaseEntities context = new HospitalDatabaseEntities())
                {
                    return (from d in context.Patients select d).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }

        public Patient GetPatient(int ID)
        {
            try
            {
                using (HospitalDatabaseEntities context = new HospitalDatabaseEntities())
                {
                    return (from d in context.Patients where d.PatientID == ID select d).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }

        public void DeletePatient(int ID)
        {
            try
            {
                using (HospitalDatabaseEntities context = new HospitalDatabaseEntities())
                {
                    context.Patients.Remove((from d in context.Patients where d.DoctorID == ID select d).FirstOrDefault());
                    context.SaveChanges();
                    MessageBox.Show("Action successfull!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void AddPatient(Patient pat)
        {
            try
            {
                using (HospitalDatabaseEntities context = new HospitalDatabaseEntities())
                {
                    context.Patients.Add(pat);
                    context.SaveChanges();
                    MessageBox.Show("Action successfull!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void UpdatePatient(Patient updatePatient)
        {
            try
            {
                using (HospitalDatabaseEntities context = new HospitalDatabaseEntities())
                {
                    Patient pat = (from d in context.Patients where d.PatientID == updatePatient.PatientID select d).FirstOrDefault();
                    pat = updatePatient;
                    context.SaveChanges();
                    MessageBox.Show("Action successfull!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
