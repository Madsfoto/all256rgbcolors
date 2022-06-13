using System;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using System.Diagnostics;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Formats.Png;


namespace all256rgbcolors
{
    internal class Program
    {

        static Color SetColor(int R, int G, int B)
        {
            // Color requires the pixels to be Rgb24 (eg 8 bit), Rgb24 requres the data to be i bytes (to fit the 0-255).
            Color colInt = new Color(new Rgba32((byte)R, (byte)G, (byte)B));


            return colInt;
        }

        
        static void Main(string[] args)
        {
            // size of the image: 
            int xSizeInt = 1024;
            int ySizeInt = 1024;
            


            // make the actual image
            Image<Rgba32> image = new Image<Rgba32>(xSizeInt, ySizeInt);
            //Image<Rgba32> imageSorted = new Image<Rgba32>(xSizeInt, ySizeInt);

            Console.WriteLine("image created");

            // GenerateInts()


            double xfactor = 256.0 / xSizeInt;
            double yfactor = 256.0 / ySizeInt;
           
            double bluefactor = 128.0/xSizeInt;
            


           
            

            for (int y = 0; y < ySizeInt; y++)
            {
                for (int x = 0; x < xSizeInt; x++)
                {
                    image[x, y] = SetColor((int)Math.Round((x*xfactor)), (int)Math.Round((y* yfactor)), (int)Math.Round(bluefactor * x+bluefactor*y));
                }

            }

            image.SaveAsPng("All256RGB.png");
            Console.WriteLine("File written");


            // read the random data into pixels: 

            // We increment this value at each position (x,y) by 3, then take the value at (arrayplacement, arrayplacement+1 and arrayplacement+2)
            // and put into the color value
            //int arrayplacement = 0;

            // go through the image
            for (int y = 0; y < ySizeInt; y++)
            {
                for (int x = 0; x < xSizeInt; x++)
                {
                    // set the actual pixel values

                    //image[x, y] = SetColor(intArr[arrayplacement], intArr[arrayplacement + 1], intArr[arrayplacement + 2]);
                    //arrayplacement = arrayplacement + 3;


                }
            }


            //Console.WriteLine("random data written to image");

            // we now have an image size filled with random pixel data
            // save the image

            //image.SaveAsPng("random.png");
            //Console.WriteLine("File written");


            //using (Image imageRS = Image.Load("random.png"))
            //{
            //    int width = imageRS.Width / 2;
            //    int height = imageRS.Height / 2;
            //    //imageRS.Mutate(x => x.Resize(width, height, KnownResamplers.Box));
            //    //imageRS.Mutate(x => x.Resize(width*16, height*16));

            //    //imageRS.SaveAsPng("RandomHalfsize.png");
            //}



        }
    }
}


