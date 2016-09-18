﻿
// =============================================
// This Class is generated by BuildProject
// Author:	Bop
// Create date:	07/09/2016 20:08
// Description:	
// Revise History:	
// =============================================

using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data.Sql;
using System.Transactions;
using System.Linq;
using System.Collections.Generic;
using BIT.Objects;
using BIT.Common;
using BIT.DataHelper;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Text;

namespace BIT.DataHelper
{ 
	public class COMMAND_DH : DataAccessBase
	{
        public int InsertWithTrans(DbTransaction trans, COMMAND obj)
        {
            var iRet = defaultDB.ExecuteScalar(trans, "sp_COMMAND_InsertReturnId"
                , obj.CommandCode, obj.UserCreate, obj.DateCreate);

            return Convert.ToInt32(iRet);
        }

		public void InsertItem(COMMAND obj)
		{
			defaultDB.ExecuteNonQuery("sp_COMMAND_Insert"
				, obj.CommandCode, obj.UserCreate, obj.DateCreate);
		}

		public void UpdateItem(COMMAND obj)
		{
			defaultDB.ExecuteNonQuery("sp_COMMAND_Update"
				, obj.ID, obj.CommandCode, obj.UserCreate, obj.DateCreate);
		}

		public void DeleteItem(int ID)
		{
			defaultDB.ExecuteNonQuery("sp_COMMAND_Delete"
				, ID);
		}

		public COMMAND SelectItem(int ID)
		{
			return defaultDB.ExecuteSprocAccessor<COMMAND>("sp_COMMAND_SelectItem"
				, ID).FirstOrDefault();
		}

		public IEnumerable<COMMAND> SelectAllItems()
		{
			return defaultDB.ExecuteSprocAccessor<COMMAND>("sp_COMMAND_SelectAllItems");
		}

		public bool IsExistsItem(int ID)
		{
			IDataReader dr  = defaultDB.ExecuteReader("sp_COMMAND_SelectItem"
				, ID);
			
			bool bol = dr.Read();
			dr.Close();
			
			return bol;
		}


        public void InsertWithTransaction(COMMAND _command, List<COMMAND_DETAIL> _lstCommandDetails, List<GH_Info> _lstGH_Admin)
        {
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Suppress))
            {
                using (DbConnection connection = defaultDB.CreateConnection())
                {
                    connection.Open();
                    try
                    {
                        using (DbTransaction transaction = connection.BeginTransaction())
                        {
                            try
                            {
                                var dhCommand = new COMMAND_DETAIL_DH();
                                var dhPH = new PH_DH();
                                var dhGH = new GH_DH();

                                // insert admin GH
                                foreach (var gh in _lstGH_Admin)
                                {
                                    var oGH = new GH { CodeId = gh.CodeId, Amount=gh.Amount, CreateDate=gh.CreateDate, CurrentAmount=gh.CurrentAmount, Status= (int)Constants.GH_STATUS.Waiting };
                                    int iGHID = dhGH.InsertAdminGHWithTrans(transaction, oGH);

                                    foreach (var com in _lstCommandDetails)
                                    {
                                        if (com.GH_ID == null && com.CodeId_To == gh.CodeId)
                                        {
                                            com.GH_ID = iGHID;
                                        }
                                    }
                                }

                                // insert command
                                int commandId = InsertWithTrans(transaction, _command);

                                // insert GH cua acc admin dua vao                                

                                // update GH_ID vao danh sach

                                // insert command details
                                foreach (var o in _lstCommandDetails)
                                {
                                    o.CommandID = commandId;

                                    dhCommand.InsertItemWithTrans(transaction, o);

                                    dhPH.UpdateStatusWithTrans(transaction, (int)o.PH_ID, (int)Constants.PH_STATUS.Pending);
                                    dhGH.UpdateStatusWithTrans(transaction, (int)o.GH_ID, (int)Constants.GH_STATUS.Pending);
                                }

                                transaction.Commit();
                                
                          }
                            catch (Exception ex)
                            {
                                transaction.Rollback();
                                throw ex;
                            }
                        }
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
                scope.Complete();
            } 
        }

        public void SendMailToPH(string username, string fullname, string mailto)
        {
            string sSubject = "BITQUICK24 Information PH GH";

            StringBuilder strBuilder = new StringBuilder();

            strBuilder.Append("<html>");
            strBuilder.Append("<head></head>");
            strBuilder.Append("<body>");
            strBuilder.Append("<table>");
            strBuilder.AppendLine("<tr><td><b>Hello  " + fullname + "</b><br/></td></tr>");
            strBuilder.AppendLine("<tr><td><b>Your PH GH has been matched </b><br/></td></tr>");
            strBuilder.AppendLine("<tr><td><b>Please log on to your account " + username +" to review your transactions and complete as soon as possible. </b><br/></td></tr>");
            strBuilder.AppendLine("<b><a href='http://bitquick24.org'>http://bitquick24.org </a></b><br/>");
            strBuilder.AppendLine("<tr><td><b>If you have any question, please contact  to us or your upline. </b><br/></td></tr>");
            strBuilder.AppendLine("<tr><td><b><br/><br/><br/>Thanks & Best regards</b><br/></td></tr>");
            strBuilder.AppendLine("<tr><td><b><br/>BITQUICK24</b><br/></td></tr>");
            strBuilder.Append("</table>");
            strBuilder.Append("</body>");
            strBuilder.Append("</html>");

            Mail.Send(mailto, sSubject, strBuilder.ToString());
        }
	}


}
