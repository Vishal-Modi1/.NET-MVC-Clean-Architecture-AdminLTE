using Microsoft.Extensions.Configuration;
using MyEhealth.Domain.Interface;
using MyEhealth.Domain.Models;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using MyEhealth.Domain.Entities;
using log4net.Core;
using log4net;
using System.Reflection;
using log4net.Config;
using System.IO;

namespace MyEhealth.Infrastructure.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly IConfiguration _configuration;
        private readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod()?.DeclaringType);

        public PatientRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        } 

        public void AddPatient(PatientModel patient)
        {
            using (var con = new SqlConnection(getSqlConnection()))
            {
                try
                {
                    SqlCommand cmd;
                    cmd = new SqlCommand("SP_CreatePatient", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Name", patient.Name);
                    cmd.Parameters.AddWithValue("@Email", patient.Email);
                    cmd.Parameters.AddWithValue("@Address", patient.Address);
                    cmd.Parameters.AddWithValue("@Mobile_Number", patient.MobileNumber);
                    cmd.Parameters.AddWithValue("@DateOfBirth", patient.DateOfBirth);
                    cmd.Parameters.AddWithValue("@Age", patient.Age);
                    cmd.Parameters.AddWithValue("@Gender", patient.Gender);
                    cmd.Parameters.AddWithValue("@BloodGroup", patient.BloodGroup);

                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception ex)
                {
                    _logger.Error(ex);
                }
            }
        }
        
        public void EditPatient(PatientModel patient)
        {
            using (var con = new SqlConnection(getSqlConnection()))
            {
                try
                {
                    SqlCommand cmd;
                    cmd = new SqlCommand("SP_UpdatePatient", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Id", patient.Id);
                    cmd.Parameters.AddWithValue("@Name", patient.Name);
                    cmd.Parameters.AddWithValue("@Email", patient.Email);
                    cmd.Parameters.AddWithValue("@Address", patient.Address);
                    cmd.Parameters.AddWithValue("@Mobile_Number", patient.MobileNumber);
                    cmd.Parameters.AddWithValue("@DateOfBirth", patient.DateOfBirth);
                    cmd.Parameters.AddWithValue("@Age", patient.Age);
                    cmd.Parameters.AddWithValue("@Gender", patient.Gender);
                    cmd.Parameters.AddWithValue("@BloodGroup", patient.BloodGroup);

                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception ex)
                {
                    _logger.Error(ex);
                }
            }
        }

        public void DeletePatient(int id)
        {
            try
            {
                using (var con = new SqlConnection(getSqlConnection()))
                {
                    SqlCommand cmd;
                    con.Open();
                    cmd = new SqlCommand("SP_DeletePatient", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
        }

        public List<PatientModel> GetAllPatient()
        {
            try
            {
                using (var con = new SqlConnection(getSqlConnection()))
                {
                    DataTable dt = new DataTable();
                    SqlDataAdapter adp = new SqlDataAdapter("SP_GetAllPatient", con);
                    adp.Fill(dt);

                    List<PatientModel> lst = new List<PatientModel>();

                    foreach (DataRow rdr in dt.Rows)
                    {
                        PatientModel patient = new PatientModel();
                        patient.Id = (int)(rdr["Id"]);
                        patient.Name = rdr["Name"].ToString();
                        patient.Email = rdr["Email"].ToString();
                        patient.MobileNumber = rdr["Mobile_Number"].ToString();
                        patient.Address = rdr["Address"].ToString();
                        patient.DateOfBirth = (DateTime)rdr["DateOfBirth"];
                        patient.Age = (int)rdr["Age"];
                        patient.Gender = rdr["Gender"].ToString();
                        patient.BloodGroup = rdr["BloodGroup"].ToString();

                        lst.Add(patient);
                    }

                    return lst;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw ex;
            }
        }

        public PatientModel GetPatientById(int id)
        {
            try
            {
                using (var con = new SqlConnection(getSqlConnection()))
                {
                    PatientModel patient = new PatientModel();
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_GetAllPatient", con);
                    //cmd.Parameters.AddWithValue("Id", id);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        patient.Id = (int)(rdr["Id"]);
                        patient.Name = rdr["Name"].ToString();
                        patient.Email = rdr["Email"].ToString();
                        patient.MobileNumber = rdr["Mobile_Number"].ToString();
                        patient.Address = rdr["Address"].ToString();
                        patient.DateOfBirth = (DateTime)rdr["DateOfBirth"];
                        patient.Age = (int)rdr["Age"];
                        patient.Gender = rdr["Gender"].ToString();
                        patient.BloodGroup = rdr["BloodGroup"].ToString();
                    }
                    con.Close();
                    return patient;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw ex;
            }
        }

        private string getSqlConnection()
        {
            return _configuration.GetSection("ConnectionString:Default").Value.ToString();
        }
    }
}
