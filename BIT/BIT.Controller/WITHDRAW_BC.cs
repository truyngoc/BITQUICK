﻿
// =============================================
// This Class is generated by BuildProject 
// Author:	Bop
// Create date:	17/08/2016 11:31
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
    public class WITHDRAW_BC
	{
        private WITHDRAW_DH ctl = new WITHDRAW_DH();

        public void InsertItem(WITHDRAW obj)		
		{
			ctl.InsertItem(obj);
		}

        public void UpdateItem(WITHDRAW obj)
		{
			ctl.UpdateItem(obj);
		}

		public void DeleteItem(int ID)
		{
			ctl.DeleteItem(ID);
		}

        public WITHDRAW SelectItem(int ID)
		{
			return ctl.SelectItem(ID);
		}

        public List<WITHDRAW> SelectAllItems()
		{
			return ctl.SelectAllItems().ToList();
		}
		
		public bool IsExistsItem(int ID)
		{
			return ctl.IsExistsItem(ID);
		}

        public WITHDRAW SelectItemByCodeId(string code_id)
        {
            return ctl.SelectItemByCodeId(code_id);
        }
	}
}