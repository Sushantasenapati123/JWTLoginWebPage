using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeGen.Model.ProjectMaster
{
    public class Project
    {
        public string resultmsg { get; set; }

        public int INTPROJECTLINKID { get; set; }
        public string NVCHPROJECTLINKNAME { get; set; }
        
        public string NVCHPROJECTLINKDESC { get; set; }
      
        public int INTCREATEDBY { get; set; }
        public int INTUPDATEDBY { get; set; }
    }
    public class ViewPoject
    {

        public int INTPROJECTLINKID { get; set; }
        public string NVCHPROJECTLINKNAME { get; set; }

        public string NVCHPROJECTLINKDESC { get; set; }

    }
    public class ViewProjectLink
    {
        public List<ViewPoject> ViewProjectLinkDetailsmodel { get; set; }
        public List<ViewPoject> ProjectLinkModelIdwise { get; set; }


    }
}

