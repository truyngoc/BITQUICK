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
	public class SNUOC_BC
	{
		private SNUOC_DH ctl = new SNUOC_DH();
				
		public List<SNUOC> SelectAllItems()
		{
			return ctl.SelectAllItems().ToList();
		}					
	}

    public class SPACKAGE_BC
    {
        private SPACKAGE_DH ctl = new SPACKAGE_DH();

        public List<SPACKAGE> SelectAllItems()
        {
            return ctl.SelectAllItems().ToList();
        }
    }

    public class PACKAGE_TRANSACTION_BC
    {
        private PACKAGE_TRANSACTION_DH ctl = new PACKAGE_TRANSACTION_DH();

        public List<PACKAGE_TRANSACTION> SelectAllItems()
        {
            return ctl.SelectAllItems().ToList();
        }

        public void InsertItem(PACKAGE_TRANSACTION obj)
        {
            ctl.InsertItem(obj);
        }

        public PACKAGE_TRANSACTION SelectItem(int id)
        {
            return ctl.SelectItem(id);
        }

        public List<PACKAGE_TRANSACTION> SelectAllItemsByCodeID(string codeID)
        {
            return ctl.SelectAllItemsByCodeID(codeID).ToList<PACKAGE_TRANSACTION>();
        }

        public void updateItem(PACKAGE_TRANSACTION obj)
        {
             ctl.updateItem(obj);
        }

        public void updateGH2(PACKAGE_TRANSACTION obj)
        {
            ctl.updateGH2(obj);
        }
        public void updateGH1(PACKAGE_TRANSACTION obj)
        {
            ctl.updateGH1(obj);
        }

        public bool isExistTransaction(string transaction)
        {
            return ctl.isExistTransaction(transaction);
        }

        public bool isAllPackageExpire(string CodeID)
        {
            return ctl.isAllPackageExpire(CodeID);
        }

        // TRUYBN - 07/09/2016
        public PACKAGE_TRANSACTION SelectItemByCodeId(string CodeId)
        {
            return ctl.SelectItemByCodeId(CodeId);
        }

        public bool IsPackageExpire(string CodeID)
        {
            return ctl.IsPackageExpire(CodeID);
        }
    }
    
}
