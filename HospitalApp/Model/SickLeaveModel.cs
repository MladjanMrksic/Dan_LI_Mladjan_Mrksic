using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HospitalApp.Model
{
    class SickLeaveModel
    {
        public List<SickLeave> GetAllSickLeaves()
        {
            try
            {
                using (HospitalDatabaseEntities context = new HospitalDatabaseEntities())
                {
                    return (from d in context.SickLeaves select d).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }

        public List<SickLeave> GetAllSickLeavesByDoctorID(int ID)
        {
            try
            {
                using (HospitalDatabaseEntities context = new HospitalDatabaseEntities())
                {
                    return (from d in context.SickLeaves where d.DoctorID == ID select d).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }
        public List<SickLeave> GetAllSickLeavesByPatientID(int ID)
        {
            try
            {
                using (HospitalDatabaseEntities context = new HospitalDatabaseEntities())
                {
                    return (from d in context.SickLeaves where d.PatientID == ID select d).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }

        public SickLeave GetSickLeave(int ID)
        {
            try
            {
                using (HospitalDatabaseEntities context = new HospitalDatabaseEntities())
                {
                    return (from d in context.SickLeaves where d.SickLeaveID == ID select d).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }

        public void DeleteSickLeave(int ID)
        {
            try
            {
                using (HospitalDatabaseEntities context = new HospitalDatabaseEntities())
                {
                    context.SickLeaves.Remove((from d in context.SickLeaves where d.SickLeaveID == ID select d).FirstOrDefault());
                    context.SaveChanges();
                    MessageBox.Show("Action successfull!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void AddSickLeave(SickLeave sl)
        {
            try
            {
                using (HospitalDatabaseEntities context = new HospitalDatabaseEntities())
                {
                    context.SickLeaves.Add(sl);
                    context.SaveChanges();
                    MessageBox.Show("Action successfull!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void UpdateSickLeave(SickLeave updateSL)
        {
            try
            {
                using (HospitalDatabaseEntities context = new HospitalDatabaseEntities())
                {
                    SickLeave sl = (from d in context.SickLeaves where d.SickLeaveID == updateSL.SickLeaveID select d).FirstOrDefault();
                    sl = updateSL;
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
