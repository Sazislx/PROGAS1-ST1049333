using System;
using System.Drawing;
using System.Security.Policy;

namespace POE_AS1_ST10493337
 {//start of namespace
     public class ascii_logo
    {//start of class
        public ascii_logo()
        {//start of constructor

            //call the ascii method
            asci();

        }//end of constructor

        //asci drawing method
        private void asci()
        {
            //path of the logo 
            string path = string.Empty;
            //auto get the full path
            string fullpath = AppDomain.CurrentDomain.BaseDirectory;
            //now combine the paths
            path = fullpath.Replace(@"bin\Debug\", "Logo.png");
            Bitmap image = new Bitmap(path);

            // Resize for better console fit
            int width = 80; 
            int height = (int)(image.Height * ((float)width / image.Width) * 0.5f); // 0.5 to fix console char height ratio
            Bitmap resized = new Bitmap(image, new Size(width, height));


            // Default color , you can set yours before this line
            Console.ForegroundColor = ConsoleColor.DarkGray;
            string asciiChars = "@#S%?*+;:,. ";

            //start by the height
            for (int y = 0; y < resized.Height; y++)
            {
                //then width
                for (int x = 0; x < resized.Width; x++)
                {
                    //color the pixel on x and y
                    Color pixel = resized.GetPixel(x, y);

                    // Convert to grayscale
                    int gray = (pixel.R + pixel.G + pixel.B) / 3;

                    // Map grayscale to ASCII
                    int index = (gray * (asciiChars.Length - 1)) / 255;

                    Console.Write(asciiChars[index]);
                }
                Console.WriteLine();
            }
        }

    }//end of class

}//end of namespace