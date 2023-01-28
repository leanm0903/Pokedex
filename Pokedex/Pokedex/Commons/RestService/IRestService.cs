using System;
using System.Threading.Tasks;

namespace Pokedex.Commons.RestService
{
	public interface IRestService
	{
        Task<TResult> GetAsync<TResult>(string uri, string token = "");

        Task<TResult> PostAsync<TRequest, TResult>(string uri, TRequest data, string token = "");

        Task<TResult> PutAsync<TRequest, TResult>(string uri, TRequest data, string token = "");
    }
}

