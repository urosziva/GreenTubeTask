using GreenTubeTask.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenTubeTask.Services
{
    public interface IDataService
    {
        Task InitData(ApiContext context);
    }
}
