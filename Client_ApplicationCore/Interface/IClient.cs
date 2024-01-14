using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client_ApplicationCore.Interface
{
    public interface IClient<TEntiy>
    {
        IList<TEntiy> List();
        void Add(TEntiy entiy);
        TEntiy Find(int Id);
        void Update(TEntiy entity);
        void Delete(int Id);
        List<TEntiy> Search(string term);
       
    }
}
