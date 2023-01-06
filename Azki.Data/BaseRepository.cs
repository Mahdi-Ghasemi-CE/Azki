using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azki.Data
{
    public class BaseRepository
    {
        protected SqlConnection Connection;

        public BaseRepository()
        {
            Connection = new SqlConnection("data source=.\\SQL2019;initial catalog=Azki_DB;" +
                                    "persist security info=True;user id=sa;password=ASD110asd;");
        }
    }
}
