using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db_biblioteca.Models.DAL
{
    internal interface IDaoScrittura<T>
    {
        bool Insert(T obj);
        bool Update(T obj);
        bool Delete(int id);
    }
}
