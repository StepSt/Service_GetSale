using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Service_GetSale
{
    public interface IBaseManager
    {
        IDprocedure GetDataBase_procedur(int IDproc);

        void SetDataBase_procedur(IDprocedure data);

        DataBase GetDataBase(int id);
        void SetDataBase(DataBase data);
        void DelDataBase_procedur(int IDproc);
        void SetDataBase_CompletionProcedures(IDprocedure data);

        User GetDataBase_user(int IDuser);

    }
}