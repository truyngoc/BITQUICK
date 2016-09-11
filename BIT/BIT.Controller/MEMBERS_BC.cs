﻿
// =============================================
// This Class is generated by BuildProject 
// Author:	Bop
// Create date:	14/08/2016 23:47
// Description:	
// Revise History:	
// =============================================

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using BIT.DataHelper;
using BIT.Objects;
using BIT.Common;

namespace BIT.Controller
{ 
	public class MEMBERS_BC
	{
		private MEMBERS_DH ctl = new MEMBERS_DH();
		
		public void InsertItem(MEMBERS obj)		
		{
			ctl.InsertItem(obj);
		}

		public void UpdateItem(MEMBERS obj)
		{
			ctl.UpdateItem(obj);
		}
        public void UpdateExpireDate(MEMBERS obj)
		{
            ctl.UpdateExpireDate(obj);
		}
        
        //quynhld 22-08
        public void UpdateLevelAndStatus(MEMBERS obj)
        {
            ctl.UpdateLevelAndStatus(obj);
        }

		public void DeleteItem(int ID)
		{
			ctl.DeleteItem(ID);
		}

        public MEMBERS SelectItemByID(int ID)
		{
			return ctl.SelectItemByID(ID);
		}
        public MEMBERS SelectItem(string CodeID)
        {
            return ctl.SelectItem(CodeID);
        }

        public MEMBERS SelectRandomAdmin()
        {
            return ctl.SelectRandomAdmin();
        }
		public List<MEMBERS> SelectAllItems()
		{
			return ctl.SelectAllItems().ToList();
		}
		
		public bool IsExistsItem(string user_name, string Wallet,string email)
		{
            return ctl.IsExistsItem(user_name, Wallet, email);
		}

        public MEMBERS SelectItemByUserName(string user_name)
        {
            return ctl.SelectItemByUserName(user_name);
        }

        public MEMBERS SelectItemByUserPass(string user_name, string pwd)
        {
            return ctl.SelectItemByUserPass(user_name, pwd);
        }

        public List<MEMBERS> SelectUplineOfUserCreate(string codeid)
        {
            return ctl.SelectUplineOfUserCreate(codeid).ToList();
        }

        public List<object> GetChartData(string user_name)
        {
            return ctl.GetChartData(user_name);
        }

        public bool CheckOldPassword(string CodeId, string oldPassword)
        {
            return ctl.CheckOldPassword(CodeId, oldPassword);
        }

        public void ChangePassword(string CodeId, string newPassword)
        {
            ctl.ChangePassword(CodeId, newPassword);
        }

        public bool CheckOldPasswordPIN(string CodeId, string oldPasswordPIN)
        {
            return ctl.CheckOldPasswordPIN(CodeId, oldPasswordPIN);
        }

        public void ChangePasswordPIN(string CodeId, string newPasswordPIN)
        {
            ctl.ChangePasswordPIN(CodeId, newPasswordPIN);
        }

        public int getNumberOfDownlineActive(string codeID)
        {
           return  ctl.getNumberOfDownlineActive(codeID);
        }

        public List<MEMBERS> getAllMemberForCalculateCommisionMonthly()
        {
            return ctl.getAllMemberForCalculateCommisionMonthly().ToList();
        }

        public DASHBOARD getInfoDashBoard(string CodeId)
        {
            return ctl.getInfoDashBoard(CodeId);
        }

        public bool IsExecutionPHSuccess(string CodeId)
        {
            return ctl.IsExecutionPHSuccess(CodeId);
        }

        public List<MEMBERS> SearchItemByUserName(string user_name)
        {
            return ctl.SearchItemByUserName(user_name).ToList();
        }

        public void LockAccount(int ID)
        {
            ctl.LockAccount(ID);
        }

        //quynhld lock by CodeID

        public void LockAccount(string CodeID)
        {
            ctl.LockAccount(CodeID);
        }


        public void UnLockAccount(int ID)
        {
            ctl.UnLockAccount(ID);
        }

        #region "TRUYBN - Show Tree BITQUICK"
        public List<MEMBERS> Tree_GetData(string Username, string CodeId_Sponsor, string Fullname, string Email, string Level)
        {
            return ctl.Tree_GetData(Username, CodeId_Sponsor, Fullname, Email, Level).ToList();
        }

        public List<MEMBERS> Tree_GetItem_By_CodeId(String CodeID)
        {
            return ctl.Tree_GetItem_By_CodeId(CodeID).ToList();
        }

        public bool CheckPasswordPIN(string CodeId, string Password_PIN)
        {
            return ctl.CheckPasswordPIN(CodeId, Password_PIN);
        }
        #endregion
	}
}
