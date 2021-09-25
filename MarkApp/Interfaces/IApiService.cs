using System;
using System.Threading.Tasks;
using MarkApp.DataObjects;

namespace MarkApp.Interfaces
{
    public interface IApiService
    {
        #region Methods
        Task<bool> PostDataAsync(Diary diary);
        #endregion
    }
}
