using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Service_GetSale
{
    public interface IBaseManager
    {
        IDprocedure GetDataBase_procedur(int IDproc);

        void SetDataBase_procedur(int IDproc, string var);

        DataBase GetDataBase(int id);
        void SetDataBase(DataBase data);
        void DelDataBase_procedur(int IDproc);
        void SetDataBase_CompletionProcedures(IDprocedure data);

        User GetDataBase_user(int IDuser);//получить данные пользователя
        void SetDataBase_User(User data); //новый пользователь
        void SetDataBase_User_Param(int IDproc, string var, string value);//изменить данные пользователя

    }
}