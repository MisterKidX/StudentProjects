using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork1
{
    class Job
    {
        public Resource[] MakingResources { get; set; }
        public Job(Resource[] MakingResources)
        {
            this.MakingResources = MakingResources;
        }
    }
}
