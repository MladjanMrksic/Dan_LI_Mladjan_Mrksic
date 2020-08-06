using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HospitalApp.Model
{
    class DoctorModel
    {
        public List<Doctor> GetAllDoctors()
        {
            try
            {
                using (HospitalDatabaseEntities context = new HospitalDatabaseEntities())
                {
                    return (from d in context.Doctors select d).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }

        public Doctor GetDoctor(int ID)
        {
            try
            {
                using (HospitalDatabaseEntities context = new HospitalDatabaseEntities())
                {
                    return (from d in context.Doctors where d.DoctorID == ID select d).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }

        public void DeleteDoctor(int ID)
        {
            try
            {
                using (HospitalDatabaseEntities context = new HospitalDatabaseEntities())
                {
                    context.Doctors.Remove((from d in context.Doctors where d.DoctorID == ID select d).FirstOrDefault());
                    context.SaveChanges();
                    MessageBox.Show("Action successfull!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void AddDoctor(Doctor doc)
        {
            try
            {
                using (HospitalDatabaseEntities context = new HospitalDatabaseEntities())
                {
                    context.Doctors.Add(doc);
                    context.SaveChanges();
                    MessageBox.Show("Action successfull!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void UpdateDoctor (Doctor updateDoc)
        {
            try
            {
                using (HospitalDatabaseEntities context = new HospitalDatabaseEntities())
                {
                    Doctor doc = (from d in context.Doctors where d.DoctorID == updateDoc.DoctorID select d).FirstOrDefault();
                    doc = updateDoc;
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
