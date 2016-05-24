using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Service_GetSale
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
       //public List<IDprocedure> iDproceduresList = new List<IDprocedure>();
       BaseManager baseManager = new BaseManager();
       public int GetIDprocedure(int IDshop, int IDuser)
       {
           Random rnd1 = new Random();
           IDprocedure iDprocedure = new IDprocedure { IDshop_class = IDshop, IDuser_class = IDuser, IDproc_class = rnd1.Next() };
           baseManager.SetDataBase_procedur(iDprocedure);
           //iDproceduresList.Add(iDprocedure);
           return iDprocedure.IDproc_class;
        }

       public int GetSale(int IDproc)
       {
           IDprocedure iDprocedure_sale = new IDprocedure();
           iDprocedure_sale = baseManager.GetDataBase_procedur(IDproc);
           DataBase dataBase = new DataBase();
           dataBase = baseManager.GetDataBase(iDprocedure_sale.IDuser_class);
           //iDprocedure_sale = iDproceduresList.Find(x => x.IDproc_class == IDproc);
           return int.Parse(dataBase.Sale_User.ToString());
       }


       public void PostUserResult(int IDproc)
       {
           IDprocedure iDprocedure_sale = new IDprocedure();
           iDprocedure_sale = baseManager.GetDataBase_procedur(IDproc);
           baseManager.SetDataBase_procedur(IDproc, "User_result");
           if (iDprocedure_sale.Shop_result == 1)
           {
               baseManager.SetDataBase_CompletionProcedures(iDprocedure_sale);
               baseManager.DelDataBase_procedur(IDproc);
           }
       }


       public void PostShopResult(int IDproc)
       {
           IDprocedure iDprocedure_sale = new IDprocedure();
           iDprocedure_sale = baseManager.GetDataBase_procedur(IDproc);
           baseManager.SetDataBase_procedur(IDproc, "Shop_result");
           if (iDprocedure_sale.User_result == 1)
           {
               baseManager.SetDataBase_CompletionProcedures(iDprocedure_sale);
               baseManager.DelDataBase_procedur(IDproc);
           }
       }


       public User GetUserParam(int IDuser)
       {
           User user = new User();
           user = baseManager.GetDataBase_user(IDuser);
           return user;
       }
    }
}
