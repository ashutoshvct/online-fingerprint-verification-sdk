using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using BiometricsSDK.FingerPrint;
using System.IO;
using System.Drawing.Imaging ; 

namespace FingerAppNet
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button butCalculate;
		private System.Windows.Forms.Button butImageProcess;
		private System.Windows.Forms.Button butOneToOneMatch;
		private System.Windows.Forms.PictureBox m_panel1;
		private System.Windows.Forms.PictureBox m_panel2;
		private System.Windows.Forms.Button butOneToManyMatch;
		private CFingerPrint m_finger1 = new CFingerPrint();
		private CFingerPrint m_finger2 = new CFingerPrint();
		private CFingerPrint m_fingermatch = new CFingerPrint();
		private Bitmap m_bimage1 ;//= new Bitmap(m_finger1.FP_IMAGE_WIDTH ,m_finger1.FP_IMAGE_HEIGHT );
		private Bitmap m_bimage2; //= new Bitmap(m_finger2.FP_IMAGE_WIDTH ,m_finger2.FP_IMAGE_HEIGHT );
		private double[] finger1;//= new double[m_finger1.FP_TEMPLATE_MAX_SIZE];
		private double[] finger2;
        private TextBox txtPicture1;
        private TextBox txtPicture2;
        private Label label1;
        private Label label2; //= new double[m_finger2.FP_TEMPLATE_MAX_SIZE];
 
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			m_bimage1 = new Bitmap(m_finger1.FP_IMAGE_WIDTH ,m_finger1.FP_IMAGE_HEIGHT );
			m_bimage2 = new Bitmap(m_finger2.FP_IMAGE_WIDTH ,m_finger2.FP_IMAGE_HEIGHT );
			finger1= new double[m_finger1.FP_TEMPLATE_MAX_SIZE];
			finger2 = new double[m_finger2.FP_TEMPLATE_MAX_SIZE];
 
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.m_panel1 = new System.Windows.Forms.PictureBox();
            this.m_panel2 = new System.Windows.Forms.PictureBox();
            this.butOneToManyMatch = new System.Windows.Forms.Button();
            this.butCalculate = new System.Windows.Forms.Button();
            this.butImageProcess = new System.Windows.Forms.Button();
            this.butOneToOneMatch = new System.Windows.Forms.Button();
            this.txtPicture1 = new System.Windows.Forms.TextBox();
            this.txtPicture2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.m_panel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_panel2)).BeginInit();
            this.SuspendLayout();
            // 
            // m_panel1
            // 
            this.m_panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.m_panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_panel1.Location = new System.Drawing.Point(8, 8);
            this.m_panel1.Name = "m_panel1";
            this.m_panel1.Size = new System.Drawing.Size(400, 400);
            this.m_panel1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.m_panel1.TabIndex = 0;
            this.m_panel1.TabStop = false;
            // 
            // m_panel2
            // 
            this.m_panel2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.m_panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_panel2.Location = new System.Drawing.Point(416, 8);
            this.m_panel2.Name = "m_panel2";
            this.m_panel2.Size = new System.Drawing.Size(400, 400);
            this.m_panel2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.m_panel2.TabIndex = 1;
            this.m_panel2.TabStop = false;
            // 
            // butOneToManyMatch
            // 
            this.butOneToManyMatch.Location = new System.Drawing.Point(832, 112);
            this.butOneToManyMatch.Name = "butOneToManyMatch";
            this.butOneToManyMatch.Size = new System.Drawing.Size(104, 23);
            this.butOneToManyMatch.TabIndex = 3;
            this.butOneToManyMatch.Text = "1 to m Match";
            this.butOneToManyMatch.Click += new System.EventHandler(this.butOneToManyMatch_Click);
            // 
            // butCalculate
            // 
            this.butCalculate.Location = new System.Drawing.Point(832, 16);
            this.butCalculate.Name = "butCalculate";
            this.butCalculate.Size = new System.Drawing.Size(104, 23);
            this.butCalculate.TabIndex = 4;
            this.butCalculate.Text = "Calculation";
            this.butCalculate.Click += new System.EventHandler(this.butCalculate_Click);
            // 
            // butImageProcess
            // 
            this.butImageProcess.Location = new System.Drawing.Point(832, 48);
            this.butImageProcess.Name = "butImageProcess";
            this.butImageProcess.Size = new System.Drawing.Size(104, 23);
            this.butImageProcess.TabIndex = 5;
            this.butImageProcess.Text = "Image Processing";
            this.butImageProcess.Click += new System.EventHandler(this.butImageProcess_Click);
            // 
            // butOneToOneMatch
            // 
            this.butOneToOneMatch.Location = new System.Drawing.Point(832, 80);
            this.butOneToOneMatch.Name = "butOneToOneMatch";
            this.butOneToOneMatch.Size = new System.Drawing.Size(104, 23);
            this.butOneToOneMatch.TabIndex = 6;
            this.butOneToOneMatch.Text = "1 to 1 Match";
            this.butOneToOneMatch.Click += new System.EventHandler(this.butOneToOneMatch_Click);
            // 
            // txtPicture1
            // 
            this.txtPicture1.Location = new System.Drawing.Point(12, 437);
            this.txtPicture1.Name = "txtPicture1";
            this.txtPicture1.Size = new System.Drawing.Size(804, 20);
            this.txtPicture1.TabIndex = 7;
            // 
            // txtPicture2
            // 
            this.txtPicture2.Location = new System.Drawing.Point(15, 476);
            this.txtPicture2.Name = "txtPicture2";
            this.txtPicture2.Size = new System.Drawing.Size(801, 20);
            this.txtPicture2.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 422);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Picture 1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 460);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Picture 2";
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(984, 502);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPicture2);
            this.Controls.Add(this.txtPicture1);
            this.Controls.Add(this.butOneToOneMatch);
            this.Controls.Add(this.butImageProcess);
            this.Controls.Add(this.butCalculate);
            this.Controls.Add(this.butOneToManyMatch);
            this.Controls.Add(this.m_panel2);
            this.Controls.Add(this.m_panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.m_panel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_panel2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		

		private void Form1_Load(object sender, System.EventArgs e)
		{
			try
			{        
				//picture1
				//Set picture new
				//m_bimage1= this.ConvertImageToBitmap( Image.FromFile("C:/FingerPrintPic/rt1.bmp"));
                txtPicture1.Text = Application.StartupPath + "\\ProcessedSample2.bmp";
                txtPicture2.Text = Application.StartupPath + "\\ProcessedSample2.bmp";
                
                m_bimage1 = (Bitmap)Image.FromFile(txtPicture1.Text);
			
				m_panel1.Image = (Image)m_bimage1;
				
                //Send image for skeletinization
				m_finger1.setFingerPrintImage(m_bimage1) ;
				finger1=m_finger1.getFingerPrintTemplate();
				
                //See what skeletinized image looks like
				m_bimage1 = m_finger1.getFingerPrintImageDetail();
				
                m_panel1.Image = (Image)m_bimage1;
				
				//picture2
				//Set picture new
                m_bimage2 = (Bitmap)Image.FromFile(txtPicture2.Text);
				m_panel2.Image = (Image)m_bimage2;
				//Send image for skeletinization
				m_finger2.setFingerPrintImage(m_bimage2) ;
				finger2=m_finger2.getFingerPrintTemplate();
				//See what skeletinized image looks like
				m_bimage2 = m_finger2.getFingerPrintImageDetail();
				m_panel2.Image = (Image)m_bimage2;
			   
    
			}
			catch (Exception ex)
			{
			MessageBox.Show(this,ex.Message);
			}        

		}

        //test image processing
        //this is where most of the work lies
        private void butImageProcess_Click(object sender, System.EventArgs e)
		{
    		try
			{
                //Set objects
                CFingerPrintGraphics fpg = new CFingerPrintGraphics();
                Bitmap originalImage = (Bitmap)Image.FromFile(Application.StartupPath + "\\Sample2.bmp");

                //show orginal image
                m_panel1.Image = (Image)originalImage;

				//start image processing
				m_bimage2=this.ConvertToGrayscale(m_bimage2);
				m_bimage2=this.Wiener(m_bimage2);

                //show changed image
                m_panel2.Image = (Image)fpg.getGreyFingerPrintImage(originalImage);
			}
			catch (Exception ex)
			{
			MessageBox.Show(this,ex.Message );
			}

		}

        private void butOneToOneMatch_Click(object sender, System.EventArgs e)
		{
			//match one print
			try
			{
		    int i = m_fingermatch.Match(finger1 , finger2,65,false);
			MessageBox.Show(i.ToString(),"Match % out of 100");
			}
			catch (Exception ex)
			{
			MessageBox.Show(this,ex.Message );
			}

		}


        private void butOneToManyMatch_Click(object sender, System.EventArgs e)
		{
			//match many finger prints
			//used to test matching speed
			//wors at about 1 match every 0,01 seconds needs to become a lot faster
			//the propriety software dose 1 match every 0,0001 a seconds
			try
			{
				DateTime m_start =DateTime.Now;
				
				for (int i = 0;i<=500;i++)
				{
					m_finger1.Match(finger1 , finger2,55,true);
					if (i == 500)
					{
						DateTime m_end =DateTime.Now;
						TimeSpan m_result ;
						m_result=m_start.Subtract(m_end);
						MessageBox.Show(this,"Match time for 500 matches"+m_result.ToString());
					}
				}
			}
			catch (Exception ex)
			{
			MessageBox.Show(this,ex.Message );
			}

		}

		
		public Bitmap ConvertToGrayscale(Bitmap source)

		{

			Bitmap bm = new Bitmap(source.Width,source.Height);

			for(int y=0;y<bm.Height;y++)

			{

				for(int x=0;x<bm.Width;x++)

				{

					Color c=source.GetPixel(x,y);

					int luma = (int)(c.R*0.3 + c.G*0.59+ c.B*0.11);

					bm.SetPixel(x,y,Color.FromArgb(luma,luma,luma));

				}

			}

			return bm;
		}

		public static bool EdgeDetectDifference(Bitmap b, byte nThreshold)
		{
			// This one works by working out the greatest difference between a 
			// pixel and it's eight neighbours. The threshold allows softer edges 
			// to be forced down to black, use 0 to negate it's effect.
			Bitmap b2 = (Bitmap) b.Clone();

			// GDI+ still lies to us - the return format is BGR, NOT RGB.
			BitmapData bmData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), 
				ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
			BitmapData bmData2 = b2.LockBits(new Rectangle(0, 0, b.Width, b.Height), 
				ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

			int stride = bmData.Stride;
			System.IntPtr Scan0 = bmData.Scan0;
			System.IntPtr Scan02 = bmData2.Scan0;

			unsafe
			{
				byte * p = (byte *)(void *)Scan0;
				byte * p2 = (byte *)(void *)Scan02;

				int nOffset = stride - b.Width*3;
				int nWidth = b.Width * 3;

				int nPixel = 0, nPixelMax = 0;

				p += stride;
				p2 += stride;

				for(int y=1;y<b.Height-1;++y)
				{
					p += 3;
					p2 += 3;

					for(int x=3; x < nWidth-3; ++x )
					{
						nPixelMax = Math.Abs((p2 - stride + 3)[0] - (p2+stride-3)[0]);
						nPixel = Math.Abs((p2 + stride + 3)[0] - (p2 - stride - 3)[0]);
						if (nPixel>nPixelMax) nPixelMax = nPixel;

						nPixel = Math.Abs((p2 - stride)[0] - (p2 + stride)[0]);
						if (nPixel>nPixelMax) nPixelMax = nPixel;

						nPixel = Math.Abs((p2+3)[0] - (p2 - 3)[0]);
						if (nPixel>nPixelMax) nPixelMax = nPixel;

						if (nPixelMax < nThreshold) nPixelMax = 0;

						p[0] = (byte) nPixelMax;

						++ p;
						++ p2;
					}

					p += 3 + nOffset;
					p2 += 3 + nOffset;
				}
			}

			b.UnlockBits(bmData);
			b2.UnlockBits(bmData2);

			return true;
    
		}

		public bool Brighten(Bitmap b, int nBrightness)
		{
			// GDI+ return format is BGR, NOT RGB.
			BitmapData bmData
				= b.LockBits(new Rectangle(0, 0, b.Width, b.Height),
				ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
			int stride = bmData.Stride;
			System.IntPtr Scan0 = bmData.Scan0;
			
			unsafe
			{
				int nVal;
				byte * p = (byte *)(void *)Scan0;
				int nOffset = stride - b.Width*3;
				int nWidth = b.Width * 3;
				for(int y=0;y<b.Height;++y)
				{
					for (int x = 0; x < nWidth; ++x)
					{
						nVal = (int) (p[0] + nBrightness);
						if (nVal < 0) nVal = 0;
						if (nVal > 255) nVal = 255;
						p[0] = (byte)nVal;
						++p;
					}
					p += nOffset;
				}
			}
			
			b.UnlockBits(bmData);
			return true;
		}//Brighten

		/// <summary>
		/// It is the Wiener Filter Function
		/// </summary>
		/// <param name="use">It is of Type Bitmap </param>
		/// <returns>Return Bitmap after Applying Wiener Filter to it.</returns>
		public  Bitmap Wiener(Bitmap use)
		{
			Bitmap wien= new Bitmap(use.Height,use.Width);
			
			//Variable's used for Calculations
			int i,j,N;
			uint tmp=0;
			uint mM,M1,mVAR;
			
			 
			// Calculating the Total Mean of the image
			for(i=0;i< use.Height;i++)
			{
				for(j=0;j<use.Width-1;j++)
				{
					Color clr = use.GetPixel(i,j);
					tmp = tmp + Convert.ToUInt32(clr.R);
				}
			}
			N = use.Height*use.Width;
			mM=Convert.ToUInt32( Math.Abs(tmp/N));
			
			// Calculating the Total Variance of the image
			tmp=0;
			for(i=0;i<use.Height ;i++)
			{
				for(j=0;j<use.Width;j++)
				{
					Color clr = use.GetPixel(i,j);
					M1= ((Convert.ToUInt32(clr.R)-mM)*(Convert.ToUInt32(clr.R)-mM));
					tmp = tmp + M1; 
				}
			}
			mVAR=Convert.ToUInt32( Math.Abs(tmp/N));
			
			//Convert the image to integer array
			uint[,] image = new uint[300,300]; 
			for(i=0;i<use.Height ;i++)
			{
				for(j=0;j<use.Width;j++)
				{
					image[i,j] = Convert.ToUInt32(use.GetPixel(i,j).R);
				}
			}
			
			int Block = 5;
			int BlockSqr = 25;
			
			// Internal Block Processing
			for(i=Block;i < use.Height-Block;i=i+1)
				for(j=Block; j < use.Width-Block;j=j+1)
				{
					int lM,lVAR;
				
					// Calculating the Mean of the Block
					tmp= 0;
					for(int k=i-Block;k<i+Block ;k=k+1)
					{
						for(int l=j-Block;l<j+Block;l=l+1)
						{
							tmp = tmp +image[k,l];
						}
					}
					lM=Convert.ToInt32( Math.Abs(tmp/BlockSqr));
									
					// Calculating the Variance of the Block
					tmp=0;
					M1=0;
					for(int k=i-Block;k< Block+i ;k=k+1)
					{
						for(int l=j-Block;l<Block+j ;l=l+1)
						{
							M1= ((image[k,l]-Convert.ToUInt32(lM))*(image[k,l]-Convert.ToUInt32(lM)));
							tmp = tmp + M1; 
						}
					}
					lVAR=Convert.ToInt32( Math.Abs(tmp/BlockSqr));

					//Putting the filtered value
					
					float tm =(lVAR-mVAR);
					float tm1 = tm/lVAR;
					int mm = Convert.ToInt32(image[i,j]-lM);
					float tm2 = tm1 * (image[i,j]-lM);
					int A = lM+Convert.ToInt32(tm2);
					
					if(A<255)
						wien.SetPixel(i,j,Color.FromArgb(255,A,A,A));  
					
				}
			return(wien);
		}


		/// <summary>
		/// Applying LowPass Filter To the Bitmap
		/// </summary>
		/// <param name="use">Takes Bitmap as the input</param>
		/// <returns>Returns Bitmap as the output after Performing Lowpass filtering</returns>
		public  Bitmap LowPass(Bitmap use)
		{
			int Rows = use.Height;
			int Cols = use.Width;
			int pixel=0;
			Bitmap LowFilter = new Bitmap(use.Height,use.Width);  
			

			for (int r=1; r< Rows-1; r++) 
				for (int c=1; c< Cols-1; c++) 
				{ 
					Color z1 = use.GetPixel(r-1,c-1);
					Color z2 = use.GetPixel(r-1,c);
					Color z3 = use.GetPixel(r-1,c+1);
					Color z4 = use.GetPixel(r,c-1);
					Color z5 = use.GetPixel(r,c);
					Color z6 = use.GetPixel(r,c+1);
					Color z7 = use.GetPixel(r+1,c-1);
					Color z8 = use.GetPixel(r+1,c);
					Color z9 = use.GetPixel(r+1,c+1);
					/* Apply Lowpass operator. */ 
					pixel = Convert.ToInt32(z3.R) +Convert.ToInt32(z1.R) +Convert.ToInt32(z6.R)+Convert.ToInt32(z4.R) +Convert.ToInt32(z9.R) +Convert.ToInt32(z7.R)+Convert.ToInt32(z2.R)+Convert.ToInt32(z5.R)+Convert.ToInt32(z8.R) ;
					pixel = pixel/9;
					/* Check magnitude */ 
					//if (pixel <255) 
					LowFilter.SetPixel(r,c,Color.FromArgb(255,pixel,pixel,pixel));
				}
			return(LowFilter);
		}
		
		/// <summary>
		/// Convert Bitmap from Grey to Binary Using Threshold Method using Mean
		/// </summary>
		/// <param name="use">Takes Bitmap as Input</param>
		/// <returns>Return Binary Image </returns>
		public  Bitmap ThreshMean(Bitmap use)
		{
			Bitmap ThreshHold = new Bitmap(use.Height,use.Width);
   
			int Rows = 15;
			int Cols = 15;

			for(int i=0;i < use.Height;i=i+15)
				for(int j=0; j < use.Width;j=j+15)
				{
					
					int r,c;
					int pixel = 0;
					int[] arr = new int[255];
					int cnt = 0;
							
					for ( r=i; r< Rows+i ; r++) 
						for (c=j; c< Cols+j ; c++) 
						{ 
							Color z1 = use.GetPixel(r,c);
							arr[cnt] = Convert.ToInt32(z1.R); 
							cnt++;
						}
					for(int k=0;k<255;k++)
						pixel = pixel+arr[k];

					pixel = pixel/255;

					for ( r=i; r< Rows+i ; r++) 
						for (c=j; c< Cols+j ; c++) 
						{ 
							//Color z1 = hist.GetPixel(r,c);
							Color z1 = use.GetPixel(r,c);
							if(pixel < Convert.ToInt32(z1.R))
								ThreshHold.SetPixel(r,c,Color.FromArgb(255,0,0,0));  
							else
								ThreshHold.SetPixel(r,c,Color.FromArgb(255,255,255,255));
						}
				
				}
			return(ThreshHold);
		}
		/// <summary>
		/// Does Histogram Processing on the Grey Scale Image
		/// </summary>
		/// <param name="use">Takes Bitmap as Input</param>
		/// <returns>Return Bitmap which is Histogram Processed</returns>
		public  Bitmap Histogram(Bitmap use)
		{
			int r,c,tmp=0;
			float[] Pixel= new float[256];
			float[] Prob = new float[256];


			//Calculating the number of pixel of same type

			for(r=0;r<use.Height;r++)
			{
				for(c=0;c<use.Width;c++)
				{
					Color cr = use.GetPixel(r,c);
					tmp = Convert.ToInt32(cr.R);
					Pixel[tmp]=Pixel[tmp]+1;
				}
			}
			//Total Number of Pixels
			int tot = use.Height*use.Width;

			//Calculating the probability
			for(r=0;r<256;r++)
			{
				if(Pixel[r]!=0)
				{
					Pixel[r]=Pixel[r]/tot; 
				}
			}
			
			//Calculating the cumulative probability
			Prob[0]=Pixel[0];
			for(r=1;r<256;r++)
			{
				Prob[r]=Prob[r-1]+Pixel[r];
			}
			
			// Generating New Graylevel Values
			for(r=0;r<256;r++)
			{
				Prob[r]=Prob[r]*255;
			}
			Bitmap hist = new Bitmap(use.Height,use.Width);
			for(r=0;r<use.Height;r++)
			{
				for(c=0;c<use.Width;c++)
				{
					Color cr = use.GetPixel(r,c);
					tmp = Convert.ToInt32(cr.R);
					hist.SetPixel(r,c,Color.FromArgb(255,Convert.ToInt32(Prob[tmp]),Convert.ToInt32(Prob[tmp]),Convert.ToInt32(Prob[tmp])));
				}
			}
			//End of Histogram
			return(hist);
		}

		/// <summary>
		/// Does the Normalization of the Grey Scale Image
		/// </summary>
		/// <param name="use">Takes Bitmap as Input</param>
		/// <returns>Returns Normalized Bitmap</returns>
		public  Bitmap Normalize(Bitmap use)
		{
			Bitmap normalized = new Bitmap(use.Height,use.Width);
			
			//Variable's used for Calculations
			int i,j,N;
			uint tmp=0;
			uint M,M1,VAR;

			// Calculating the Mean of the image
			for(i=0;i< use.Height -1;i++)
			{
				for(j=0;j<use.Width-1;j++)
				{
					Color clr = use.GetPixel(i,j);
					tmp = tmp + Convert.ToUInt32(clr.R);
				}
			}
			N = use.Height*use.Width;
			M=Convert.ToUInt32( Math.Abs(tmp/N));
			 
			// Calculating the Variance of the image
			tmp=0;
			for(i=0;i<use.Height -1;i++)
			{
				for(j=0;j<use.Width-1;j++)
				{
					Color clr = use.GetPixel(i,j);
					M1= ((Convert.ToUInt32(clr.R)-M)*(Convert.ToUInt32(clr.R)-M));
					tmp = tmp + M1; 
				}
			}
			VAR=Convert.ToUInt32( Math.Abs(tmp/N));

			uint MO =100,VARO =100,newInten;
			Color Inten;

			for(i=0;i<use.Height -1;i++)
			{
				for(j=0;j<use.Width-1;j++)
				{
					Inten = use.GetPixel(i,j);
					if(Convert.ToUInt32(Inten.R) > M)
					{
						newInten = MO + Convert.ToUInt32(Math.Sqrt((VARO*((Convert.ToUInt32(Inten.R)-M)*(Convert.ToUInt32(Inten.R)-M)))/VAR));
						normalized.SetPixel(i,j,Color.FromArgb(255,Convert.ToInt32(newInten),Convert.ToInt16(newInten),Convert.ToInt16(newInten)));
					}
					else
					{
						newInten = MO - Convert.ToUInt32(Math.Sqrt((VARO*((Convert.ToUInt32(Inten.R)-M)*(Convert.ToUInt32(Inten.R)-M)))/VAR));
						normalized.SetPixel(i,j,Color.FromArgb(255,Convert.ToInt32(newInten),Convert.ToInt16(newInten),Convert.ToInt16(newInten)));
					}
				}
			}		
			return(normalized);
			//End of Normalization
		}


		
		
		
		/// <summary>
		/// This Function Does Sekelotonization to the Binary Image
		/// </summary>
		/// <param name="use">Takes Binary Image as Input</param>
		/// <returns>Return Thined Binar Image</returns>
		public  Bitmap ThinMean(Bitmap use) 
		{
			
			bool success3 = true;
			while(success3)
			{
				bool success = false ;
				bool success2 = false;
				int count ;
				int count2;
				int num_transitions ;
				int[,] picture = new int[300,300];
				int[,] temp_array= new int[300,300];
				int transitions ;
				int[,] temp = new int[300,300];

				for (int h = 0; h < 300; h++) 
					for (int w = 0; w < 300; w++) 
					{
						picture[h,w] =Convert.ToInt32(use.GetPixel(h,w).R); 
					}

				for (int i = 1; i < 300-1; i++) 
				{
					for (int j = 1; j < 300-1; j++) 
					{
						count = 0;
						num_transitions = 0;

						// check  for N(p)
						if (picture[i,j] == 255) 
						{
							if (picture[i-1,j-1] != 0)
								count++;
							if (picture[i,j-1] != 0)
								count++;
							if (picture[i+1,j-1] != 0)
								count++;
							if (picture[i+1,j] != 0) 
								count++;
							if (picture[i-1,j] != 0)
								count++;
							if (picture[i+1,j+1] != 0)
								count++;
							if (picture[i,j+1] != 0) 
								count++;
							if (picture[i-1,j+1] != 0)
								count++;
        
							if (count != 8) 
							{
								// 2 <= N(p) <= 6
								if (count >= 2 && count <= 6) 
								{
									if(picture[i-1,j] == 0 && picture[i-1,j+1] == 255)
										num_transitions++ ;
									if(picture[i-1,j+1] == 0 && picture[i,j+1] == 255)
										num_transitions++ ;
									if(picture[i,j+1] == 0 && picture[i+1,j+1] == 255)
										num_transitions++ ;
									if(picture[i+1,j+1] == 0 && picture[i+1,j] == 255)
										num_transitions++ ;
									if(picture[i+1,j] == 0 && picture[i+1,j-1] == 255)
										num_transitions++ ;
									if(picture[i+1,j-1] == 0 && picture[i,j-1] == 255)
										num_transitions++ ;
									if(picture[i,j-1] == 0 && picture[i-1,j-1] == 255)
										num_transitions++ ;
									if(picture[i-1,j-1] == 0 && picture[i-1,j] == 255)
										num_transitions++ ;

									//S(p) = 1
									if (num_transitions == 1) 
									{
										// if p2 * p4 * p6 = 0
										if (picture[i-1,j] == 0 || picture[i,j+1] == 0 ||
											picture[i+1,j] == 0)
										{
											// if p4 * p6 * p8 = 0 
											if(picture[i,j+1] == 0 || picture [i+1,j] == 0 ||picture[i,j-1] == 0) 
											{
												temp_array[i,j] = 0;
												success = true;
											} 
											else
												temp_array[i,j] = 255;
										} 
										else
											temp_array[i,j] = 255;
									}
									else 
										temp_array[i,j] = 255 ;
								}   
								else
									temp_array[i,j] = 255 ;
							}
							else
								temp_array[i,j] = 255;
						}
						else
							temp_array[i,j] = 0;    
					}
				}
				//copy thinned image back to original
				for (int a = 0; a < 300; a++) 
				{
					for (int b = 0; b < 300; b++) 
						picture[a,b] = temp_array[a,b];
				} 
		
  
				// step 2 of the thinning algorithm 
				for (int k = 0; k < 300; k++) 
				{
					for (int l = 0; l < 300; l++) 
					{
						count2 = 0;
						transitions = 0;
						if (picture[k,l] == 255) 
						{
							if (picture[k-1,l-1] != 0)
								count2++;
							if (picture[k,l-1] != 0)
								count2++;
							if (picture[k+1,l-1] != 0)
								count2++;
							if (picture[k+1,l] != 0)
								count2++;
							if (picture[k-1,l] != 0)
								count2++;
							if (picture[k+1,l+1] != 0)
								count2++;
							if (picture[k,l+1] != 0)
								count2++;
							if (picture[k-1,l+1] != 0)
								count2++;

							if (count2 != 8)
							{ 
								if (count2 >= 2 && count2 <= 6) 
								{
									if(picture[k-1,l] == 0 && picture[k-1,l+1] == 255)
										transitions++ ;
									if(picture[k-1,l+1] == 0 && picture[k,l+1] == 255)
										transitions++ ;
									if(picture[k,l+1] == 0 && picture[k+1,l+1] == 255)
										transitions++ ;
									if(picture[k+1,l+1] == 0 && picture[k+1,l] == 255)
										transitions++ ;
									if(picture[k+1,l] == 0 && picture[k+1,l-1] == 255)
										transitions++ ;
									if(picture[k+1,l-1] == 0 && picture[k,l-1] == 255)
										transitions++ ;
									if(picture[k,l-1] == 0 && picture[k-1,l-1] == 255)
										transitions++ ;
									if(picture[k-1,l-1] == 0 && picture[k-1,l] == 255)
										transitions++ ;

									if (transitions == 1) 
									{
										// if p2 * p4 * p8 = 0
										if(picture[k-1,l] == 0 || picture[k,l+1] == 0 ||picture[k,l-1] == 0)
										{
											// if p2 * p6 * p8
											if(picture[k-1,l] == 0 || picture[k+1,l] == 0 ||picture[k,l-1] == 0)
											{
												temp[k,l] = 0;
												success2 = true;
											}
											else
												temp[k,l] = 255;
										}
										else
											temp[k,l] = 255;
									}
									else
										temp[k,l] = 255;   
								}
								else
									temp[k,l] = 255;
							}
							else
								temp[k,l] = 255;
						}
						else
							temp[k,l] = 0;
					}
				}

				for (int a = 0; a < 300; a++) 
					for (int b = 0; b < 300; b++)
					{
						int tmp = temp[a,b];
						use.SetPixel(a,b,Color.FromArgb(255,tmp,tmp,tmp));  
					}

				
				if(success || success2)        
					success3= true; 
				else
					success3= false;
			}
			
			return(use);
		}
		/// <summary>
		/// Applys Sobel Operator to the Grey Scale Image
		/// </summary>
		/// <param name="use">Takes Grey Scale Image as Input</param>
		/// <returns>Return Grey Scale Image after applying Sobel Operator </returns>
		public  Bitmap Sobel(Bitmap use)
		{
			int Rows = use.Height;
			int Cols = use.Width;
			int r,c;
			int pixel;
			Bitmap sobel = new Bitmap(Rows,Cols); 
			Bitmap gx = new Bitmap(Rows,Cols);
			Bitmap gy = new Bitmap(Rows,Cols);

			pixel=0;
			for (r=1; r< Rows-1; r++) 
				for (c=1; c< Cols-1; c++) 
				{ 

					int[] z = new Int32[10]; 
					z[1] = Convert.ToInt32(use.GetPixel(r-1,c-1).R);
					z[3] = Convert.ToInt32(use.GetPixel(r-1,c+1).R);
					z[4] = Convert.ToInt32(use.GetPixel(r,c-1).R);
					z[6] = Convert.ToInt32(use.GetPixel(r,c+1).R);
					z[7] = Convert.ToInt32(use.GetPixel(r+1,c-1).R);
					z[9] = Convert.ToInt32(use.GetPixel(r+1,c+1).R);
					/* Apply Sobel operator. */ 
					pixel = z[3] -z[1] +(2*z[6] )-(2*z[4] )+z[9] -z[7] ;

					/* Normalize and take absolute value */ 
					pixel = Math.Abs(pixel); 
				
					/* Check magnitude */ 
					if (pixel <255) 
						gy.SetPixel(r,c,Color.FromArgb(255,pixel,pixel,pixel));
				}

			pixel =0;
			for (r=1; r< Rows-1; r++) 
				for (c=1; c< Cols-1; c++) 
				{ 
					int[] z = new Int32[10];

					z[1] = Convert.ToInt32(use.GetPixel(r-1,c-1).R) ;
					z[3] = Convert.ToInt32(use.GetPixel(r-1,c+1).R) ;
					z[2] = Convert.ToInt32(use.GetPixel(r-1,c).R) ;
					z[8] = Convert.ToInt32(use.GetPixel(r+1,c).R) ;
					z[7] = Convert.ToInt32(use.GetPixel(r+1,c-1).R) ;
					z[9] = Convert.ToInt32(use.GetPixel(r+1,c+1).R) ;
					/* Apply Sobel operator. */ 
					pixel = z[7]-z[1]+(2*z[8])-(2*z[2])+z[9]-z[3];

					/* Normalize and take absolute value */ 
					pixel = Math.Abs(pixel); 
				
					/* Check magnitude */ 
					if (pixel <255) 
						gx.SetPixel(r,c,Color.FromArgb(255,pixel,pixel,pixel));
				}

			pixel =0;
			for(r=0;r<Rows;r++)
				for(c=0;c<Cols;c++)
				{
					Color x = gx.GetPixel(r,c);
					Color y = gy.GetPixel(r,c);
					pixel = Convert.ToInt32(x.R) + Convert.ToInt32(y.R );

					if (pixel <255) 
						sobel.SetPixel(r,c,Color.FromArgb(255,pixel,pixel,pixel));
				}
			return(sobel);
		}

        private void butCalculate_Click(object sender, EventArgs e)
        {

        }
	}
}
