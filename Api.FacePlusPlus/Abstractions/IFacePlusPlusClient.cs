using System.Collections.Generic;
using System.Threading.Tasks;
using Api.FacePlusPlus.Models;

namespace Api.FacePlusPlus.Abstractions
{
    public interface IFacePlusPlusClient
    {
        Task<FacePlusPlusDetectResult> GetEmotionsForPhoto(string photoUrl);
    }
}