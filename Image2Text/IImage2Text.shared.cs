using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EA.Image2Text
{
    public interface IImage2Text
    {
        Task<List<string>> GetStringsFromImage(Image ImageWithText);
    }
}
