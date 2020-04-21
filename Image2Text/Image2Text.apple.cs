using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EA.Image2Text
{
    /// <summary>
    /// Interface for Image2Text
    /// </summary>
    public class Image2TextImplementation : IImage2Text
    {
        public Task<List<string>> GetStringsFromImage(Image ImageWithText)
        {
            throw new NotImplementedException("Not available");
        }
    }
}
