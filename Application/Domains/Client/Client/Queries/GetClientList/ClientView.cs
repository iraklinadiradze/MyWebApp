using System;
using System.Collections.Generic;
using System.Text;

using DataAccessLayer.Model.Client;


namespace Application.Domains.Client.Client.Queries.GetClientList
{
    public class ClientView: List<DataAccessLayer.Model.Client.Client>
    {

    }


    /*
        public class container
        {

            int prop1 { get; set; }
            int prop2 { get; set; }
            int prop3 { get; set; }
            int prop4 { get; set; }
            int prop5 { get; set; }

            private class nested
            {
                int nprop1 { get; set; }
                int nprop2 { get; set; }
                int nprop3 { get; set; }
            }


            nested prop6 { get; set; }
        }
    */

}
