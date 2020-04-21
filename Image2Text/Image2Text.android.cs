using Android.Gms.Vision.Texts;
using Android.Graphics;
using Android.Util;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace EA.Image2Text
{
    /// <summary>
    /// Interface for Image2Text
    /// </summary>
    public class Image2TextImplementation : IImage2Text
    {
        public async Task<List<string>> GetStringsFromImage(Image ImageWithText)
        {
            try
            {
                var result = new List<string>();

                Bitmap img = null;

                var imageHandler = GetHandler(ImageWithText.Source);
                if (imageHandler != null)
                {
                    img = await imageHandler.LoadImageAsync(ImageWithText.Source, Android.App.Application.Context); // needs context for Android
                }

                var txtRecognizer = new TextRecognizer.Builder(Android.App.Application.Context).Build();

                if (!txtRecognizer.IsOperational)
                {
                    throw new NotImplementedException("Detector dependencies are not yet available");
                }
                else
                {
                    Android.Gms.Vision.Frame frame = new Android.Gms.Vision.Frame.Builder().SetBitmap(img).Build();

                    SparseArray items = txtRecognizer.Detect(frame);

                    for (int i = 0; i < items.Size(); i++)
                    {
                        TextBlock item = (TextBlock)items.ValueAt(i);

                        result.Add(item.Value);
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException($"Error: {ex.Message}");
            }
        }

        private IImageSourceHandler GetHandler(ImageSource source)
        {
            //Image source handler to return 
            IImageSourceHandler returnValue = null;
            //check the specific source type and return the correct image source handler 
            if (source is UriImageSource)
            {
                returnValue = new ImageLoaderSourceHandler();
            }
            else if (source is FileImageSource)
            {
                returnValue = new FileImageSourceHandler();
            }
            else if (source is StreamImageSource)
            {
                returnValue = new StreamImagesourceHandler();
            }
            return returnValue;
        }
    }
}
