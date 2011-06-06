/* 
    Biometric SDK
    Version 1.3

    This file contains functions that manipulate , extract features and match
    fingerprint images.
 
    Copyright (C) 2005  Scott Johnston
    Email :  moleisking@googlemail.com
 
    This program is free software; you can redistribute it and/or
    modify it under the terms of the GNU General Public License
    as published by the Free Software Foundation; either version 2
    of the License, or (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program; if not, write to the Free Software
    Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA. 
*/


/// <summery>
/// A lot of work needs to be done here.
///  
/// What needs to be done:
///  
/// This class is ment for code that is going to do preprocesing of the image before we
/// pass it to the CFingerPrint Class.The Sample pictures need to be transformed from what they look
/// like in Sample1 to what they look like in ProcessedSample.
///  
/// This will require the use of a edge detetection algorithim and some fillters, so if you can help 
/// and submit the code and the results of your processed samples to me it would be much apreciated.
///  
/// You won t get very far with fillters. What needs to be done is that you can do a couple of fillters. 
/// Each one extracting a different part of the image. For example just do a filter for the grey then the 
/// black. You then can then "add" the two images to each other. 
/// 
/// </summery> 
 

using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace BiometricsSDK.FingerPrint
{
	/// <summary>
	/// Summary description for CFingerPrintGraphics.
	/// </summary>
	/// 
	

	public class CFingerPrintGraphics
	{
		public int FP_IMAGE_WIDTH = 323;
		public int FP_IMAGE_HEIGHT = 352;
        Bitmap _originalImage;

		public CFingerPrintGraphics()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public CFingerPrintGraphics(int width , int height )
		{
			FP_IMAGE_WIDTH = width;
			FP_IMAGE_HEIGHT = height;
		}

        public CFingerPrintGraphics(Bitmap originalImage)
        {
            _originalImage = originalImage;
        }

		public Bitmap getGreyFingerPrintImage(Bitmap originalImage)
		{
            Bitmap resultImage = new Bitmap(originalImage.Width, originalImage.Height );
			// float mask[] = {  -1f/5,1f/5,-1f/5
			//                    ,1f/5,9f/5,1f/5
			//                    ,-1f/5,1f/5,-1f/5};    
      
			//     float mask[] = { 
			//       5f/100,10f/100,5f/100
			//      ,10f/100,40f/100,10f/100
			//      ,5f/100,10f/100,5f/100
			//                 };    
     
			//float mask[] = {  -1f/4,0,0,0,0,0,0
			//                  ,0,-1f/2,0,0,0,0,0
			//                  ,0,0,-1f/4,0,0,0,0
			//                  ,0,0,0,1,0,0,0
			//                  ,0,0,0,0,0,0,0
			//                  ,0,0,0,0,0,0,0
			//                  ,0,0,0,0,0,0,0
              
			// };    
   
			float[] mask = 
			{
				1f/16,0f,-1f/16
				,2f/16,0f,-2f/16
				,1f/16,0f,-1f/16
                      
			};
                 
			System.Drawing.Drawing2D.Matrix k = new Matrix(); 
			
			//Kernel k = new Kernel(3,3, mask);                
			//BufferedImageOp con = new ConvolveOp(k, ConvolveOp.EDGE_NO_OP,null);
			//con.filter(m_original_image , m_result_image);
			/*
			   for (int i = 0; i<= FP_IMAGE_WIDTH-1;i++)
			   {
				  for (int j = 0;j<= FP_IMAGE_HEIGHT-1;j++)
				  {
			  Color c = new Color(m_result_image.getRGB(i,j));
					  if ((c.getBlue()  == 0) && (c.getRed()  == 0) && (c.getGreen()  == 0))
					  {
						m_result_image.setRGB(i,j,Color.blue.getRGB());
					  }
					  else
					  {
						m_result_image.setRGB(i,j,Color.white.getRGB());
					  }

				  }//end for j
			  }//end for i
		*/
       
			return resultImage;
		}//getGreyFingerPrintImage
	}
}
