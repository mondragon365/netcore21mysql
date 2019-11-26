using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Net.Http;
using System.Linq;

namespace mysqlconnector
{
    public class BlogPostQuery
    {
        public AppDb Db { get; }

        public BlogPostQuery(AppDb db)
        {
            Db = db;
        }      

        public List<BlogPost> LatestPostsAsync()
        {
            List<BlogPost> lista = new List<BlogPost>();
            var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"SELECT `Id`, `Title`, `Content` FROM `BlogPost` ORDER BY `Id` DESC LIMIT 10;";
            //var  tmp=await cmd.ExecuteReaderAsync();
            MySqlDataReader myReader;
            myReader = cmd.ExecuteReader();
            lista = myReader.HydrateRows<BlogPost>().ToList();
            return lista;
        }
       
    }
}